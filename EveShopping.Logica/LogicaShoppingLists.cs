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

namespace EveShopping.Logica
{
    public class LogicaShoppingLists
    {
        public IEnumerable<FittingAnalyzed> ObtenerListaFits(string fitOriginal){
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

        public eshShoppingList SelectShoppingListByPublicID(string publicID){
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
            sl.dateCreation = System.DateTime.Now;
            sl.dateUpdate = System.DateTime.Now;
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

            eshShoppingListInvType slit = repo.UpdateMarketItemEnShoppingList(list.shoppingListID, itemID, units);
        }

        public eshShoppingListFitting SetUnitsToFitInShoppingList(string publicID, int id, short units)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            eshShoppingListFitting slfit = (from sl in contexto.eshShoppingLists
                                            join slf in contexto.eshShoppingListsFittings.Include("eshFitting.eshFittingHardwares") on sl.shoppingListID equals slf.shoppingListID
                                            where sl.publicID == publicID && slf.fittingID == id
                                            select slf).FirstOrDefault();
            
            if (slfit == null) throw new ApplicationException(Messages.err_fittingNoExiste);


            if (units < 0) units = 0;           
            slfit.units = units;
            contexto.SaveChanges();

            return slfit;
        }

        public void DeleteItemFromShoppingList(string publicID, int itemID){
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

        public IList<MarketItem> SelectMarketItemsEnShoppingList(string publicID)
        {
            EveShoppingContext context = new EveShoppingContext();

            IList<MarketItem> miList = new List<MarketItem>();

            eshShoppingList shl = context.eshShoppingLists.Where( s => s.publicID == publicID).FirstOrDefault();

            if (shl == null) throw new ApplicationException(Messages.err_shoppingLisNoExiste);

            IEnumerable<eshShoppingListInvType> listaSlit =
                context.eshShoppingListsInvTypes.Include("invType").Where(l => l.shoppingListID == shl.shoppingListID);

            foreach (var slit in listaSlit)
            {
                MarketItem mi = new MarketItem();
                mi.ItemID = slit.typeID;
                mi.Name = slit.invType.typeName;
                mi.Units = slit.units;
                mi.Volume = slit.volume;
                mi.URI = string.Format(Constantes.EVEImageServerFormat32, slit.typeID);
                miList.Add(mi);
            }
            return miList;
        }
            
        public MarketItem SelectMarketItemByID(string shoppingListPublicID, int id)
        {
            EveShoppingContext context = new EveShoppingContext();
            eshShoppingList slist = context.eshShoppingLists.Where(sl => sl.publicID == shoppingListPublicID).FirstOrDefault();

            if (slist == null) throw new ApplicationException(Messages.err_shoppingLisNoExiste);

            eshShoppingListInvType slitype = context.eshShoppingListsInvTypes.Include("invType").Where(slit => slit.shoppingListID == slist.shoppingListID && slit.typeID == id).FirstOrDefault();
            if (slitype == null) throw new ApplicationException(Messages.err_itemNoEnShoppingList);

            RepositorioItems repo = new RepositorioItems();

            MarketItem mi = new MarketItem
            {
                ItemID = slitype.typeID,
                Name = slitype.invType.typeName,
                Units = slitype.units,
                URI = string.Format(Constantes.EVEImageServerFormat32, slitype.typeID),
                Volume = repo.GetVolume(slitype.invType) * slitype.units
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
            salida.shipVolume =  repo.GetVolume( shipType);

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
            salida.volume = repo.GetVolume( tipo) * fithwd.Units;
            
            return salida;
        }


    }
}
