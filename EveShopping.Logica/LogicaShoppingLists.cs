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

namespace EveShopping.Logica
{
    public class LogicaShoppingLists
    {
        public IEnumerable<FittingAnalyzed> ObtenerListaFits(string fitOriginal)
        {
            IConversorFit conv = null;
            IEnumerable<FittingAnalyzed> salida = null;
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

        public eshFitting SelectFitPorID(int fittingID)
        {
            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            return repo.SelectFitPorID(fittingID);
        }

        /// <summary>
        /// si el id no existe no se hace nada
        /// </summary>
        /// <param name="fittingID"></param>
        public void DeleteFitPorID(int fittingID)
        {
            EveShoppingContext context = new EveShoppingContext();
            eshFitting fit = context.eshFittings.Where(f => f.fittingID == fittingID).FirstOrDefault();
            context.eshFittings.Remove(fit);

            context.SaveChanges();
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
            IEnumerable<EVFitting> fittings =
                (from sl in contexto.eshShoppingLists
                 join slf in contexto.eshShoppingListsFittings on sl.shoppingListID equals slf.shoppingListID
                 join f in contexto.eshFittings on slf.fittingID equals f.fittingID
                 join it in contexto.invTypes on f.shipTypeID equals it.typeID
                 join p in contexto.eshPrices on new { sl.tradeHubID, it.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                 where sl.publicID == publicID
                 select new EVFitting
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
                     Volume = f.shipVolume * slf.units
                 }).ToList();

            foreach (var fit in fittings)
            {
                fit.ShipImageUrl32 = imageResolver.GetImageURL(fit.ShipID);

                var qfittingHardwares =
                   (from sl in contexto.eshShoppingLists
                    join slf in contexto.eshShoppingListsFittings on sl.shoppingListID equals slf.shoppingListID
                    join f in contexto.eshFittings on slf.fittingID equals f.fittingID
                    join fh in contexto.eshFittingHardwares on f.fittingID equals fh.fittingID
                    join it in contexto.invTypes on fh.typeID equals it.typeID
                    join mg in contexto.invMarketGroups on it.marketGroupID equals mg.marketGroupID
                    join p in contexto.eshPrices on new { sl.tradeHubID, it.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                    where f.fittingID == fit.FittingID
                    orderby fh.slotID, fh.positionInSlot, fh.invType.typeName
                    select new EVFittingHardware
                    {
                        ItemID = fh.typeID,
                        GroupName = mg.marketGroupName,
                        Name = it.typeName,
                        TotalPrice = fh.units * p.avg,
                        Slot = fh.slotID,
                        SlotName = fh.eshFittingSlot.name,
                        Units = fh.units,
                        Volume = fh.units * it.volume.Value

                    });
                foreach (var item in qfittingHardwares)
                {
                    item.ImageUrl32 = imageResolver.GetImageURL(item.ItemID);
                    fit.FittingHardwares.Add(item);
                    fit.Price += item.TotalPrice * fit.Units;
                    fit.Volume += item.Volume * fit.Units;
                }
            }
            
            return fittings;
        }

        public eshShoppingList SelectShoppingListByPublicID(string publicID)
        {
            EveShoppingContext contexto =
                new EveShoppingContext();

            return contexto.eshShoppingLists.Include("eshShoppingListFittings.eshFitting.eshFittingHardwares.invType")
                .Include("eshShoppingListInvTypes.invType").Where(sl => sl.publicID == publicID).FirstOrDefault();
        }

        public IEnumerable<eshShoppingListFitting> SelectFitsEnShoppingList(string publicID)
        {
            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            return repo.SelectFitsEnShoppingList(publicID);
        }

        public string CrearShoppingList(string name, string description)
        {
            string publicID = Guid.NewGuid().ToString();
            EveShoppingContext contexto = new EveShoppingContext();

            eshShoppingList sl = new eshShoppingList();
            sl.name = name;
            sl.description = description;
            sl.publicID = publicID;
            sl.readOnlypublicID = Guid.NewGuid().ToString();
            sl.dateCreation = System.DateTime.Now;
            sl.dateUpdate = System.DateTime.Now;
            sl.tradeHubID = 30000142;
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

        public void UpdateMarketItemToShoppingList(string publicID, int itemID, short units)
        {
            RepositorioShoppingLists repo = new RepositorioShoppingLists();
            eshShoppingList list = repo.SelectShopingListPorPublicID(publicID);
            if (units < 1) units = 1;
            eshShoppingListInvType slit = repo.UpdateMarketItemEnShoppingList(list.shoppingListID, itemID, units);
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
         FittingID = f.fittingID,
         Name = f.name,
         ShipID = f.shipTypeID.Value,
         ShipName = f.invType.typeName,
         ShipVolume = f.shipVolume,
         Units = slf.units,
         ShipPrice = p.avg,
         Price = p.avg * slf.units,
         Volume = f.shipVolume * slf.units
     }).FirstOrDefault();

            fit.ShipImageUrl32 = imageResolver.GetImageURL(fit.ShipID);

            var qfittingHardwares =
               (from sl in contexto.eshShoppingLists
                join slf in contexto.eshShoppingListsFittings on sl.shoppingListID equals slf.shoppingListID
                join f in contexto.eshFittings on slf.fittingID equals f.fittingID
                join fh in contexto.eshFittingHardwares on f.fittingID equals fh.fittingID
                join it in contexto.invTypes on fh.typeID equals it.typeID
                join mg in contexto.invMarketGroups on it.marketGroupID equals mg.marketGroupID
                join p in contexto.eshPrices on new { sl.tradeHubID, it.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                where f.fittingID == fit.FittingID
                orderby fh.slotID, fh.positionInSlot, fh.invType.typeName
                select new EVFittingHardware
                {
                    ItemID = fh.typeID,
                    GroupName = mg.marketGroupName,
                    Name = it.typeName,
                    TotalPrice = fh.units * p.avg,
                    Slot = fh.slotID,
                    SlotName = fh.eshFittingSlot.name,
                    Units = fh.units,
                    Volume = fh.units * it.volume.Value

                });
            foreach (var item in qfittingHardwares)
            {
                item.ImageUrl32 = imageResolver.GetImageURL(item.ItemID);
                fit.FittingHardwares.Add(item);
                fit.Price += item.TotalPrice * fit.Units;
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
                EVFittingHardware fw =
                    new EVFittingHardware
                    {
                        Name = fit.ShipName,
                        ItemID = fit.ShipID,
                        Units = fit.Units,
                        Volume = fit.ShipVolume * fit.Units,
                        TotalPrice = fit.ShipPrice * fit.Units,
                        ImageUrl32 = imageResolver.GetImageURL(fit.ShipID)
                    };
                diccHwd.Add(fw.ItemID, fw);
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
                        fw.Volume += fw.Volume * fit.Units;
                        fw.TotalPrice += fw.TotalPrice * fit.Units;
                    }
                    else
                    {
                        fw.Units *= fit.Units;
                        fw.Volume *= fit.Units;
                        fw.TotalPrice *= fit.Units;
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
                    fwd.Units = mi.Units;
                    fwd.Volume = mi.Volume;
                    diccHwd.Add(fwd.ItemID, fwd);
                }
            }
            foreach (var item in diccHwd.Values)
            {
                summary.Items.Add(item);
                summary.TotalPrice += item.TotalPrice;
                summary.TotalVolume += item.Volume;                
            }

            return summary;

        }

        public EVFitting SetUnitsToFitInShoppingList(string publicID, int fittingID, short units, IImageResolver imageResolver)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            //guardamos los cambios
            eshShoppingListFitting slfit = contexto.eshShoppingListsFittings.Where(slf => slf.fittingID == fittingID && slf.eshShoppingList.publicID == publicID).FirstOrDefault();
            if (slfit == null) throw new ApplicationException(Messages.err_fittingNoExiste);
            if (units < 1) units = 1;
            slfit.units = units;
            contexto.SaveChanges();

            //obtenemos la fitting
            return this.SelectFitSummary(publicID, fittingID, imageResolver);
        }

        public void DeleteItemFromShoppingList(string publicID, int itemID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            RepositorioShoppingLists repo = new RepositorioShoppingLists(contexto);
            eshShoppingList list = repo.SelectShopingListPorPublicID(publicID);

            eshShoppingListInvType item = repo.SelectMarketItemEnShoppingListPorID(list.shoppingListID, itemID);

            contexto.eshShoppingListsInvTypes.Remove(item);
            contexto.SaveChanges();
        }

        public int SaveAnalisedFit(string listPublicId, FittingAnalyzed fitAnalysed, int? userId = null)
        {
            eshShoppingList lista = null;
            eshFitting fit = null;
            using (TransactionScope scope = new TransactionScope())
            {
                RepositorioShoppingLists repo = new RepositorioShoppingLists();
                lista = repo.SelectShopingListPorPublicID(listPublicId);

                if (lista == null)
                {
                    lista = new eshShoppingList();
                    lista.publicID = listPublicId;
                    repo.CrearShoppingList(lista);
                }
                fit = MountFittingFromFittingAnalysed(fitAnalysed);
                eshShoppingListFitting relation = new eshShoppingListFitting();
                fit.eshShoppingListFittings.Add(relation);
                relation.eshShoppingList = lista;
                relation.units = 1;

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
                throw new ApplicationException(Messages.err_nombreItemAnalizadaNoExiste);
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
