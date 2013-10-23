using EveShopping.Logica.Conversion;
using EveShopping.Modelo;
using EveShopping.Modelo.Models;
using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using EveShopping.Repositorios;
using EveShopping.Modelo.EV;
using EveShopping.Logica.QEntities;
using EveShopping.Loggin;

namespace EveShopping.Logica
{
    public class LogicaShoppingLists
    {

        public int GetListCountByUser(string userName)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            var count =
                (from f in contexto.eshShoppingLists
                 join u in contexto.userProfiles on f.userID equals u.UserId
                 where u.UserName == userName
                 select f.shoppingListID).Count();

            count +=
                (from f in contexto.eshGroupShoppingLists
                    join u in contexto.userProfiles on f.userID equals u.UserId
                    where u.UserName == userName
                    select f.groupShoppingListID).Count();


            return count;
        }

        public IEnumerable<FittingAnalyzed> ObtenerListaFits(string fitOriginal)
        {
            try
            {
                IConversorFit conv = null;
                IEnumerable<FittingAnalyzed> salida = null;

                conv = new ConversorDNAToFitList();
                try
                {
                    salida = conv.ToFitList(fitOriginal);
                    if (salida != null)
                    {
                        return salida;
                    }
                }
                catch (Exception ex)
                {
                }


                conv = new ConversorEFTToFitList();
                try
                {
                    salida = conv.ToFitList(fitOriginal);
                    if (salida != null)
                    {
                        return salida;
                    }
                }
                catch (FittingFormatNotRecognisedException ex)
                {
                }

                conv = new ConversorEveXmlToFitList();
                salida = conv.ToFitList(fitOriginal);

                if (salida == null)
                {
                    throw new FittingFormatNotRecognisedException(Messages.err_fittingNoExiste);
                }
                return salida;
            }
            catch (Exception)
            {
                VSHLoggin.Log(eLogSeverity.warning, ErrCodes.ERR_FailAnalysingFit, fitOriginal);
                throw;
            }
        }

        public eshFitting SelectFitPorID(int fittingID)
        {
            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            return repo.SelectFitPorID(fittingID);
        }

        public void DeleteShoppingList(string publicID, string userName)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            using (TransactionScope scope = new TransactionScope())
            {


                eshShoppingList sl = contexto.eshShoppingLists.Where(s => s.publicID == publicID).FirstOrDefault();
                if (sl == null) throw new ApplicationException(Messages.err_shoppingLisNoExiste);

                if (sl.userID.HasValue && userName == null) throw new ApplicationException(Messages.err_notOwner);

                UserProfile user = contexto.userProfiles.Where(u => u.UserName == userName).FirstOrDefault();

                if (sl.userID.HasValue && sl.userID.Value != user.UserId) throw new ApplicationException(Messages.err_notOwner);

                //passed the user right test, the shopping list can be deleted based on the owner.

                //At this moment we dont make any further test regarding if the list used or not, it is possible to delete only based on the ownership.

                //Delete the related static lists
                LogicaSnapshots logicaSnaps = new LogicaSnapshots();
                List<eshSnapshot> listSnapshots = sl.eshSnapshots.ToList();
                foreach (var snp in listSnapshots)
                {
                    logicaSnaps.DeleteStaticShoppingList(snp, userName, contexto);
                }
                List<eshShoppingListFitting> listFittings = sl.eshShoppingListFittings.ToList();
                foreach (var fit in listFittings)
                {
                    this.DeleteFitFromShoppingLIST(sl.shoppingListID, fit.fittingID, contexto);
                }
                List<eshShoppingListInvType> listInvtTypes = sl.eshShoppingListInvTypes.ToList();
                foreach (var it in listInvtTypes)
                {
                    this.DeleteItemFromShoppingList(sl.shoppingListID, it.typeID, contexto);
                }

                ClearAllDeltaFromSummary(sl, contexto);

                contexto.eshShoppingLists.Remove(sl);

                contexto.SaveChanges();
                scope.Complete();
            }

        }


        public void DeleteFitFromShoppingLIST(int id, int fittingID, EveShoppingContext context)
        {
            eshFitting fit = context.eshFittings.Where(f => f.fittingID == fittingID).FirstOrDefault();

            eshShoppingListFitting slf = context.eshShoppingListsFittings.Where(s => s.shoppingListID == id && s.fittingID == fit.fittingID).FirstOrDefault();
            context.eshShoppingListsFittings.Remove(slf);

            if (!fit.userID.HasValue)
            {
                context.eshFittings.Remove(fit);
            }

            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            foreach (var item in fit.eshShoppingListFittings)
            {
                repo.ShoppingListUpdated(item.shoppingListID, context);
            }


            context.SaveChanges();
        }

        /// <summary>
        /// si el id no existe no se hace nada
        /// </summary>
        /// <param name="fittingID"></param>
        public void DeleteFitFromShoppingLIST(string publicID, int fittingID)
        {
            EveShoppingContext context = new EveShoppingContext();

            eshShoppingList sl = context.eshShoppingLists.Where(s => s.publicID == publicID).FirstOrDefault();
            if (sl == null) throw new ApplicationException(Messages.err_shoppingLisNoExiste);
            if (sl != null)
            {
                DeleteFitFromShoppingLIST(sl.shoppingListID, fittingID, context);
            }
        }

        public string GetPublidIDPorPublidIDRead(string publicIDRead)
        {
            EveShoppingContext contexto =
                new EveShoppingContext();
            eshShoppingList list = contexto.eshShoppingLists.Where(s => s.readOnlypublicID == publicIDRead).FirstOrDefault();

            if (list == null)
            {
                list = contexto.eshShoppingLists.Where(s => s.publicID == publicIDRead).FirstOrDefault();
            }
            if (list == null)
            {
                throw new ApplicationException(Messages.err_shoppingLisNoExiste);
            }
            return list.publicID;


        }

        public IEnumerable<EVFitting> SelectFitsInShoppingList(string publicID, IImageResolver imageResolver)
        {
            EveShoppingContext contexto =
                new EveShoppingContext();
            List<EVFitting> fittings = new List<EVFitting>();
            IEnumerable<QFitting> qfittings =
                (from sl in contexto.eshShoppingLists
                 join slf in contexto.eshShoppingListsFittings on sl.shoppingListID equals slf.shoppingListID
                 join f in contexto.eshFittings on slf.fittingID equals f.fittingID
                 join it in contexto.invTypes on f.shipTypeID equals it.typeID
                 join p in contexto.eshPrices on new { sl.tradeHubID, it.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                 where sl.publicID == publicID
                 select new QFitting
                 {
                     Description = f.description,
                     FittingID = f.fittingID,
                     Name = f.name,
                     ShipID = f.shipTypeID.Value,
                     ShipName = f.invType.typeName,
                     ShipVolume = f.shipVolume,
                     Units = slf.units,
                     ShipPrice = p.avg,
                     Price = p.avg * slf.units,
                     Volume = f.shipVolume * slf.units,
                     InvType = it

                 });
            int tradeHubID = contexto.eshShoppingLists.Where(s => s.publicID == publicID).FirstOrDefault().tradeHubID;

            LogicaFittings logicaFittings = new LogicaFittings();
            return logicaFittings.MountFittingCommon(contexto, qfittings, imageResolver, tradeHubID);
        }

        public bool IsShoppingListFree(string publicID)
        {
            EveShoppingContext contexto =
                new EveShoppingContext();
            eshShoppingList list = contexto.eshShoppingLists.Where(sl => sl.publicID == publicID).FirstOrDefault();

            if (list == null)
            {
                throw new ApplicationException(Messages.err_shoppingLisNoExiste);
            }
            return !list.userID.HasValue;
        }

        public eshShoppingList SelectShoppingListByPublicID(string publicID)
        {
            EveShoppingContext contexto =
                new EveShoppingContext();

            return contexto.eshShoppingLists.Include("eshShoppingListFittings.eshFitting.eshFittingHardwares.invType")
                .Include("eshShoppingListInvTypes.invType").Where(sl => sl.publicID == publicID).FirstOrDefault();
        }

        public IList<EVShoppingListHeader> SelectShoppingListsByUserName(string userName)
        {
            EveShoppingContext contexto =
                new EveShoppingContext();

            UserProfile user = contexto.userProfiles.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefault();

            if (user == null)
            {
                throw new ApplicationException(Messages.err_usuarioNoExiste);
            }

            var query = from u in contexto.userProfiles
                        join sl in contexto.eshShoppingLists on u.UserId equals sl.userID.Value
                        where u.UserName == userName
                        select new EVShoppingListHeader
                        {
                            dateCreation = sl.dateCreation,
                            dateUpdate = sl.dateUpdate,
                            name = sl.name,
                            publicID = sl.publicID,
                            staticCount = sl.eshSnapshots.Count
                        };
            return query.ToList();

            //return user.eshShoppingLists.OrderByDescending(sl => sl.dateAccess).ToList();
        }

        public IEnumerable<eshShoppingListFitting> SelectFitsEnShoppingList(string publicID)
        {
            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            return repo.SelectFitsEnShoppingList(publicID);
        }

        public string CrearShoppingList(string name, string description, string userName = null)
        {
            string publicID = Guid.NewGuid().ToString();
            EveShoppingContext contexto = new EveShoppingContext();

            int? userId = null;
            if (userName != null)
            {
                UserProfile up = contexto.userProfiles.Where(p => p.UserName == userName).FirstOrDefault();
                if (up == null) throw new ApplicationException(Messages.err_usuarioNoExiste);
                userId = up.UserId;

            }

            eshShoppingList sl = new eshShoppingList();
            sl.name = name;
            sl.description = description;
            sl.publicID = publicID;
            sl.readOnlypublicID = Guid.NewGuid().ToString();
            sl.dateCreation = System.DateTime.Now;
            sl.dateUpdate = System.DateTime.Now;
            sl.dateAccess = System.DateTime.Now;
            sl.tradeHubID = 30000142;
            sl.userID = userId;
            contexto.eshShoppingLists.Add(sl);
            contexto.SaveChanges();
            return publicID;

        }



        public string CrearShoppingList(eshShoppingList lista)
        {
            string publicID = Guid.NewGuid().ToString();
            lista.publicID = publicID;
            EveShoppingContext contexto = new EveShoppingContext();
            contexto.eshShoppingLists.Add(lista);
            contexto.SaveChanges();
            return publicID;
        }

        public void SaveListInMyLists(string publicID, string userName)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshShoppingList list = contexto.eshShoppingLists.Where(sl => sl.publicID == publicID).FirstOrDefault();
            if (list == null)
            {
                throw new ApplicationException(Messages.err_shoppingLisNoExiste);
            }

            //si la shopping list ya tiene un propietario no lo cambiamos.
            if (list.userID.HasValue) return;

            UserProfile user = contexto.userProfiles.Where(up => up.UserName == userName).FirstOrDefault();
            if (user == null)
            {
                throw new ApplicationException(Messages.err_usuarioNoExiste);
            }

            foreach (var slf in list.eshShoppingListFittings)
            {
                if (slf.eshFitting != null && !slf.eshFitting.userID.HasValue)
                {
                    slf.eshFitting.userID = user.UserId;
                }
            }

            list.userID = user.UserId;
            contexto.SaveChanges();
        }

        public void ActualizarShoppingListHeader(string publicID, string slName, string slDescription)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshShoppingList sl = null;
            sl = contexto.eshShoppingLists.Where(s => s.publicID == publicID).FirstOrDefault();
            sl.name = slName;
            sl.description = slDescription;
            sl.dateUpdate = DateTime.Now;
            sl.dateAccess = DateTime.Now;
            contexto.SaveChanges();
        }

        public void UpdateMarketItemToShoppingList(string publicID, int itemID, short units)
        {
            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            eshShoppingList list = repo.SelectShopingListPorPublicID(publicID);
            if (units < 1) units = 1;
            eshShoppingListInvType slit = repo.UpdateMarketItemEnShoppingList(list.shoppingListID, itemID, units);
            repo.ShoppingListUpdated(list.shoppingListID);
        }

        public void ClearAllDeltaFromSummary(string publicID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshShoppingList list = contexto.eshShoppingLists.Where(sl => sl.publicID == publicID).FirstOrDefault();
            ClearAllDeltaFromSummary(list, contexto);
        }

        internal void ClearAllDeltaFromSummary(eshShoppingList sl, EveShoppingContext contexto)
        {
            sl.eshShoppingListSummInvTypes.Clear();
            contexto.SaveChanges();
        }



        public void UpdateDeltaToSummary(string publicID, int itemID, short units)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshShoppingList list = contexto.eshShoppingLists.Where(sl => sl.publicID == publicID).FirstOrDefault();
            ChangesSummaryItem changes = new ChangesSummaryItem();

            if (list == null) throw new ApplicationException(Messages.err_shoppingLisNoExiste);

            eshShoppingListSummInvType summEntry = contexto.eshShoppingListSummInvTypes.Where(si => si.shoppingListID == list.shoppingListID && si.typeID == itemID).FirstOrDefault();

            if (units != 0)
            {
                if (summEntry == null)
                {
                    summEntry = new eshShoppingListSummInvType();
                    summEntry.typeID = itemID;
                    summEntry.shoppingListID = list.shoppingListID;
                    contexto.eshShoppingListSummInvTypes.Add(summEntry);
                }
                summEntry.delta = units;
            }
            else
            {
                if (summEntry != null)
                {
                    contexto.eshShoppingListSummInvTypes.Remove(summEntry);
                }
            }
            list.dateUpdate = DateTime.Now;
            list.dateAccess = DateTime.Now;

            contexto.SaveChanges();
        }



        public EVFitting SelectFitSummary(string publicID, int fittingID, IImageResolver imageResolver)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            EVFitting fit =
    (from slf in contexto.eshShoppingListsFittings
     join f in contexto.eshFittings on slf.fittingID equals f.fittingID
     join it in contexto.invTypes on f.shipTypeID equals it.typeID
     join p in contexto.eshPrices on new { tradeHubID = slf.eshShoppingList.tradeHubID, it.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
     where slf.eshShoppingList.publicID == publicID && slf.fittingID == fittingID
     select new EVFitting
     {
         Description = f.description,
         ItemID = f.fittingID,
         Name = f.name,
         ShipID = f.shipTypeID.Value,
         ShipName = f.invType.typeName,
         ShipVolume = f.shipVolume,
         Units = slf.units,
         ShipPrice = p.avg,
         TotalPrice = p.avg * slf.units,
         Volume = f.shipVolume * slf.units
     }).FirstOrDefault();

            fit.ImageUrl32 = imageResolver.GetImageURL(fit.ShipID);

            var qfittingHardwares =
               (from sl in contexto.eshShoppingLists
                join slf in contexto.eshShoppingListsFittings on sl.shoppingListID equals slf.shoppingListID
                join f in contexto.eshFittings on slf.fittingID equals f.fittingID
                join fh in contexto.eshFittingHardwares on f.fittingID equals fh.fittingID
                join it in contexto.invTypes on fh.typeID equals it.typeID
                join mg in contexto.invMarketGroups on it.marketGroupID equals mg.marketGroupID
                join p in contexto.eshPrices on new { sl.tradeHubID, it.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                where f.fittingID == fit.ItemID
                orderby fh.slotID, fh.positionInSlot, fh.invType.typeName
                select new EVFittingHardware
                {
                    ItemID = fh.typeID,
                    GroupName = mg.marketGroupName,
                    Name = it.typeName,
                    TotalPrice = fh.units * p.avg,
                    UnitPrice = fh.units,
                    Slot = fh.slotID,
                    SlotName = fh.eshFittingSlot.name,
                    Units = fh.units,
                    Volume = fh.units * it.volume.Value

                });
            foreach (var item in qfittingHardwares)
            {
                item.ImageUrl32 = imageResolver.GetImageURL(item.ItemID);
                fit.FittingHardwares.Add(item);
                fit.TotalPrice += item.TotalPrice * fit.Units;
                fit.Volume += item.Volume * fit.Units;
            }

            return fit;

        }

        public EVListSummary SelectListSummaryPorPublicID(string publicID, IImageResolver imageResolver)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshShoppingList shoppingList = contexto.eshShoppingLists.Where(sl => sl.publicID == publicID).FirstOrDefault();

            EVListSummary summary =
                new EVListSummary();
            summary.Description = shoppingList.description;
            summary.Name = shoppingList.name;
            summary.PublicID = shoppingList.publicID;
            summary.ReadOnlyPublicID = shoppingList.readOnlypublicID;
            summary.ShoppingListID = shoppingList.shoppingListID;


            IEnumerable<EVFitting> fittings = this.SelectFitsInShoppingList(publicID, imageResolver);

            Dictionary<int, EVFittingHardware> diccHwd = new Dictionary<int, EVFittingHardware>();

            //add ships
            foreach (var fit in fittings)
            {
                EVFittingHardware fw = null;
                if (diccHwd.ContainsKey(fit.ShipID))
                {
                    fw = diccHwd[fit.ShipID];
                    fw.Units += fit.Units;
                    fw.Volume += fit.Units * fit.ShipVolume;
                    fw.TotalPrice += fit.ShipPrice * fit.Units;
                }
                else
                {
                    fw = new EVFittingHardware
                    {
                        Name = fit.ShipName,
                        ItemID = fit.ShipID,
                        Units = fit.Units,
                        Volume = fit.ShipVolume * fit.Units,
                        UnitVolume = fit.ShipVolume,
                        TotalPrice = fit.ShipPrice * fit.Units,
                        UnitPrice = fit.ShipPrice,
                        ImageUrl32 = imageResolver.GetImageURL(fit.ShipID)
                    };
                    diccHwd.Add(fw.ItemID, fw);
                }


            }
            //add fitted hardware
            foreach (var fit in fittings)
            {
                foreach (var fw in fit.FittingHardwares)
                {
                    if (diccHwd.ContainsKey(fw.ItemID))
                    {
                        EVFittingHardware fwd = diccHwd[fw.ItemID];
                        fwd.Units += fw.Units * fit.Units;
                        fwd.Volume += fw.Volume * fit.Units;
                        fwd.TotalPrice += fw.TotalPrice * fit.Units;
                        //fw.UnitPrice = fw.TotalPrice;
                    }
                    else
                    {
                        fw.Units *= fit.Units;
                        fw.Volume *= fit.Units;
                        fw.TotalPrice *= fit.Units;
                        if (fit.Units != 0)
                        {
                            fw.UnitVolume = fw.Volume / fw.Units;
                            fw.UnitPrice = fw.TotalPrice / fw.Units;
                        }
                        else
                        {
                            fw.UnitVolume = fw.Volume;
                            fw.UnitPrice = fw.TotalPrice;
                        }
                        diccHwd.Add(fw.ItemID, fw);
                    }
                }
            }
            //add market items
            IEnumerable<MarketItem> marketItems = this.SelectMarketItemsEnShoppingList(publicID, imageResolver);
            foreach (var mi in marketItems)
            {
                if (diccHwd.ContainsKey(mi.ItemID))
                {
                    EVFittingHardware fwd = diccHwd[mi.ItemID];
                    fwd.Units += mi.Units;
                    fwd.Volume += mi.Volume;
                    fwd.TotalPrice += mi.TotalPrice;
                }
                else
                {
                    EVFittingHardware fwd = new EVFittingHardware();
                    fwd.ImageUrl32 = mi.ImageUrl32;
                    fwd.ItemID = mi.ItemID;
                    fwd.Name = mi.Name;
                    fwd.TotalPrice = mi.TotalPrice;
                    fwd.UnitPrice = mi.UnitPrice;
                    fwd.Units = mi.Units;
                    fwd.Volume = mi.Volume;
                    fwd.UnitVolume = mi.Volume / mi.Units;
                    diccHwd.Add(fwd.ItemID, fwd);
                }
            }

            // Update summary changes
            IEnumerable<eshShoppingListSummInvType> summInvs =
                contexto.eshShoppingListSummInvTypes.Where(sls => sls.shoppingListID == summary.ShoppingListID);
            foreach (var summInv in summInvs)
            {
                if (!diccHwd.ContainsKey(summInv.typeID))
                {
                    //if the item is not in the items dictionary, it doesnt exist anymore in the list, so we delete the delta
                    contexto.eshShoppingListSummInvTypes.Remove(summInv);
                }
                else
                {
                    EVFittingHardware fwd = diccHwd[summInv.typeID];
                    if ((summInv.delta < 0) && (summInv.delta * -1 > fwd.Units))
                    {
                        summInv.delta = (short)(fwd.Units * -1);
                    }
                    fwd.TotalPrice += summInv.delta * fwd.UnitPrice;
                    fwd.Volume += (fwd.Volume / fwd.Units) * summInv.delta;
                    fwd.Units += summInv.delta;
                    fwd.Delta = summInv.delta;
                }

            }

            foreach (var item in diccHwd.Values)
            {
                summary.Items.Add(item);
                summary.TotalPrice += item.TotalPrice;
                summary.TotalVolume += item.Volume;
            }

            contexto.SaveChanges();

            return summary;

        }

        public void UseFitInList(string publicID, int fitID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshShoppingList sl = contexto.eshShoppingLists.Where(s => s.publicID == publicID).FirstOrDefault();
            if (sl == null)
            {
                throw new ApplicationException(Messages.err_shoppingLisNoExiste);
            }
            if (contexto.eshShoppingListsFittings.Where(slf => slf.shoppingListID == sl.shoppingListID && slf.fittingID == fitID).Count() > 0)
            {
                throw new ApplicationException(Messages.err_fittigAlreadyUsed);
            }
            eshShoppingListFitting slft = new eshShoppingListFitting();
            slft.shoppingListID = sl.shoppingListID;
            slft.fittingID = fitID;
            slft.units = 1;
            contexto.eshShoppingListsFittings.Add(slft);
            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            repo.ShoppingListUpdated(sl.shoppingListID, contexto);
            contexto.SaveChanges();

        }


        public EVFitting SetUnitsToFitInShoppingList(string publicID, int fittingID, short units, IImageResolver imageResolver)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            //guardamos los cambios
            eshShoppingListFitting slfit = contexto.eshShoppingListsFittings.Where(slf => slf.fittingID == fittingID && slf.eshShoppingList.publicID == publicID).FirstOrDefault();
            if (slfit == null) throw new ApplicationException(Messages.err_fittingNoExiste);
            if (units < 1) units = 1;
            slfit.units = units;
            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            repo.ShoppingListUpdated(slfit.shoppingListID, contexto);
            contexto.SaveChanges();

            //obtenemos la fitting
            return this.SelectFitSummary(publicID, fittingID, imageResolver);
        }

        internal void DeleteItemFromShoppingList(int id, int itemID, EveShoppingContext contexto = null)
        {
            RepositorioShoppingLists repo = new RepositorioShoppingLists(contexto);
            eshShoppingListInvType item = repo.SelectMarketItemEnShoppingListPorID(id, itemID);

            contexto.eshShoppingListsInvTypes.Remove(item);
            repo.ShoppingListUpdated(id, contexto);
            contexto.SaveChanges();

        }

        public void DeleteItemFromShoppingList(string publicID, int itemID)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            RepositorioShoppingLists repo = new RepositorioShoppingLists(contexto);
            eshShoppingList list = repo.SelectShopingListPorPublicID(publicID);

        }

        public int SaveAnalisedFit(string listPublicId, FittingAnalyzed fitAnalysed, string userName = null)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            eshShoppingList lista = null;
            eshFitting fit = null;
            using (TransactionScope scope = new TransactionScope())
            {
                fit = MountFittingFromFittingAnalysed(fitAnalysed);

                RepositorioShoppingLists repo = new RepositorioShoppingLists(contexto);
                if (!string.IsNullOrEmpty(listPublicId))
                {
                    lista = repo.SelectShopingListPorPublicID(listPublicId);
                    eshShoppingListFitting relation = new eshShoppingListFitting();
                    fit.eshShoppingListFittings.Add(relation);
                    relation.eshShoppingList = lista;
                    relation.units = 1;
                    repo.ShoppingListUpdated(lista.shoppingListID);
                }

                if (!string.IsNullOrEmpty(userName))
                {
                    UserProfile up = contexto.userProfiles.Where(u => u.UserName == userName).FirstOrDefault();
                    if (up == null) throw new ApplicationException(Messages.err_usuarioNoExiste);
                    fit.userID = up.UserId;
                }

                repo.CrearFitting(fit);

                scope.Complete();
            }
            return fit.fittingID;
        }

        public IList<MarketItem> SelectMarketItemsEnShoppingList(string publicID, IImageResolver imageResolver)
        {
            EveShoppingContext context = new EveShoppingContext();

            IList<MarketItem> miList = new List<MarketItem>();

            var qlistaItems =
                (from sl in context.eshShoppingLists
                 join slit in context.eshShoppingListsInvTypes on sl.shoppingListID equals slit.shoppingListID
                 join it in context.invTypes on slit.typeID equals it.typeID
                 join p in context.eshPrices on new { sl.tradeHubID, slit.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                 where sl.publicID == publicID
                 select new
                 {
                     ItemID = slit.typeID,
                     Name = it.typeName,
                     Units = slit.units,
                     TotalPrice = p.avg * slit.units,
                     invType = it

                 });
            foreach (var item in qlistaItems)
            {
                MarketItem mi =
                    new MarketItem()
                    {
                        ItemID = item.ItemID,
                        Name = item.Name,
                        Units = item.Units,
                        TotalPrice = item.TotalPrice,
                        UnitPrice = item.TotalPrice / item.Units,
                        Volume = RepositorioItems.GetVolume(item.invType) * item.Units,
                        ImageUrl32 = imageResolver.GetImageURL(item.ItemID)

                    };
                miList.Add(mi);
            }

            return miList;
        }

        public MarketItem SelectMarketItemByID(string publicID, int id, IImageResolver imageResolver)
        {
            EveShoppingContext context = new EveShoppingContext();


            var qmi =
                (from sl in context.eshShoppingLists
                 join slit in context.eshShoppingListsInvTypes on sl.shoppingListID equals slit.shoppingListID
                 join it in context.invTypes on slit.typeID equals it.typeID
                 join p in context.eshPrices on new { sl.tradeHubID, slit.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                 where sl.publicID == publicID && slit.typeID == id
                 select new
                 {
                     ItemID = slit.typeID,
                     Name = it.typeName,
                     Units = slit.units,
                     TotalPrice = p.avg * slit.units,
                     Volume = it.volume.Value * slit.units,
                     ItemType = it
                 }).FirstOrDefault();
            MarketItem mi = new MarketItem()
            {
                ItemID = qmi.ItemID,
                Name = qmi.Name,
                Units = qmi.Units,
                TotalPrice = qmi.TotalPrice,
                UnitPrice = qmi.TotalPrice / qmi.Units,
                Volume = RepositorioItems.GetVolume(qmi.ItemType) * qmi.Units,
                ImageUrl32 = imageResolver.GetImageURL(qmi.ItemID)
            };

            return mi;
        }


        public eshFitting MountFittingFromFittingAnalysed(FittingAnalyzed fit)
        {
            RepositorioItems repo = new RepositorioItems();

            eshFitting salida = new eshFitting();
            salida.name = fit.Name;
            salida.description = fit.Description;
            invType shipType = repo.SelectItemTypePorName(fit.Ship);
            if (shipType == null)
            {
                throw new ApplicationException(Messages.err_nombreItemAnalizadaNoExiste);
            }
            salida.shipTypeID = shipType.typeID;
            salida.shipVolume = RepositorioItems.GetVolume(shipType);

            double totalVol = salida.shipVolume;
            foreach (var item in fit.Items)
            {
                eshFittingHardware fhwd = MountFittingHardware(item, repo);
                salida.eshFittingHardwares.Add(fhwd);
                totalVol += fhwd.volume;
            }
            salida.volume = totalVol;


            return salida;
        }

        public eshFittingHardware MountFittingHardware(FittingHardwareAnalyzed fithwd, RepositorioItems repo)
        {
            invType tipo = repo.SelectItemTypePorName(fithwd.Name);
            if (tipo == null)
            {
                throw new ApplicationException(string.Format("{0}: {1}", Messages.err_nombreItemAnalizadaNoExiste, fithwd.Name));
            }
            eshFittingHardware salida = new eshFittingHardware();
            salida.typeID = tipo.typeID;
            salida.positionInSlot = 0;
            salida.slotID = fithwd.Slot;
            salida.units = fithwd.Units;
            salida.volume = RepositorioItems.GetVolume(tipo) * fithwd.Units;

            return salida;
        }


    }
}
