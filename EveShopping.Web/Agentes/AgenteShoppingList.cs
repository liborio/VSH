using EveShopping.Logica;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.EV;
using EveShopping.Modelo.Models;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EveShopping.Web.Agentes
{
    public class AgenteShoppingList
    {


        public static decimal CalculateTotalPrice(IEnumerable<EVFitting> fittings) 
        {
            decimal total = 0;
            foreach (var item in fittings)
            {
                total += item.TotalPrice;
            }
            return total;
        }


        public static double CalculateTotalVolume(IEnumerable<EVFitting> fittins) 
        {
            double total = 0;
            foreach (var item in fittins)
            {
                total += item.Volume;
            }
            return total;
        }

        public static decimal CalculateTotalPrice<T>(IEnumerable<T> fittings) where T:BaseItem{
            decimal total = 0;
            foreach (var item in fittings){
                total += item.TotalPrice;
            }
            return total;
        }


        public static double CalculateTotalVolume<T>(IEnumerable<T> fittins) where T : BaseItem
        {
            double total = 0;
            foreach (var item in fittins)
            {
                total += item.Volume;
            }
            return total;
        }

        public bool IsShoppingListFree(string publicID)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            return logica.IsShoppingListFree(publicID);
        }

        public string CrearShoppingList(string name, string description, string userName = null)
        {            
            LogicaShoppingLists logica = new LogicaShoppingLists();
            return logica.CrearShoppingList(name, description, userName);
        }

        public void DeleteShoppingList(string publicID, string userName)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            logica.DeleteShoppingList(publicID, userName);
        }

        public void ActualizarShoppingListHeader(string publicID, string slName, string slDescription)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            logica.ActualizarShoppingListHeader(publicID, slName, slDescription);

        }

        public void SaveListInMyListsIfProceed(HttpRequestBase request, IIdentity identity, string publicId)
        {
            if (identity.IsAuthenticated && string.Equals(request.Params["save"], "1"))
            {
                LogicaShoppingLists logica = new LogicaShoppingLists();
                logica.SaveListInMyLists(publicId, identity.Name);
            }
        }

        public int SaveAnalysedFit(string publicID, string userName, FittingAnalyzed fitAnalysed)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            return logica.SaveAnalisedFit(publicID, fitAnalysed, userName);
        }

        public EVFitting SelectFitPorID(string publicID, int fittingID)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            return logica.SelectFitSummary(publicID, fittingID, new Imagex32UrlResolver());
        }

        public EVListSummary SelectListSummaryPorPublicIDRead(string publicIDRead)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            string publicID = logica.GetPublidIDPorPublidIDRead(publicIDRead);
            return SelectListSummaryPorPublicID(publicID);
        }

        public void UseFitInList(string publicID, int fitID)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            logica.UseFitInList(publicID, fitID);
        }

        public eshSnapshot CreateStaticShoppingList(string publicID)
        {
            LogicaSnapshots logica = new LogicaSnapshots();
            return logica.CreateStaticShoppingList(publicID, null, new Imagex32UrlResolver());
        }

        public void DeleteStaticShoppingList(string publicID, string userName)
        {
            LogicaSnapshots logica = new LogicaSnapshots();
             logica.DeleteStaticShoppingList(publicID, userName);
        }

        public IEnumerable<EVStaticList> SelectStaticListsByShoppingListPublicID(string publicID)
        {
            LogicaSnapshots logica = new LogicaSnapshots();
            return logica.SelectStaticListsByShoppingListPublidID(publicID);
        }

        public eshSnapshot SelectStaticListByPublicID(string publicID)
        {
            LogicaSnapshots logica = new LogicaSnapshots();
            return logica.SelectStaticListByPublicID(publicID);
        }

        public IList<EVShoppingListHeader> SelectShoppingListsByUserName(string userName)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            return logica.SelectShoppingListsByUserName(userName);
        }


        public EVListSummary SelectListSummaryPorPublicID(string publicID)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            return logica.SelectListSummaryPorPublicID(publicID, new Imagex32UrlResolver());
            //eshShoppingList sl = logica.SelectShoppingListByPublicID(publicID);

            //EVListSummary summ = new EVListSummary();
            //summ.Name = sl.name;
            //summ.Description = sl.description;
            //summ.PublicID = sl.publicID;


            

            //Dictionary<int, EVFittingHardware> diccHardware = new Dictionary<int, EVFittingHardware>();

            //foreach (var shfit in sl.eshShoppingListFittings)
            //{
            //    EVFittingHardware fh = diccHardware.ContainsKey(shfit.eshFitting.shipTypeID.Value) ? diccHardware[shfit.eshFitting.shipTypeID.Value] : null;
    
            //    if (fh == null)
            //    {
            //        fh = new EVFittingHardware();
            //        fh.ItemID = shfit.eshFitting.shipTypeID.Value;
            //        fh.Name = shfit.eshFitting.name;
            //        fh.ImageUrl32 = GetImageUrl32(shfit.eshFitting.shipTypeID.Value);
            //        summ.Items.Add(fh);
            //        diccHardware.Add(fh.ItemID, fh);
            //    }
            //    fh.Units += shfit.units;
            //    fh.Volume += shfit.units * shfit.eshFitting.shipVolume;                

            //}

            //foreach (var slit in sl.eshShoppingListInvTypes)
            //{
            //    EVFittingHardware fh = diccHardware.ContainsKey(slit.typeID) ? diccHardware[slit.typeID] : null;

            //    if (fh == null)
            //    {
            //        fh = new EVFittingHardware();
            //        fh.ItemID = slit.typeID;
            //        fh.Name = slit.invType.typeName;
            //        fh.ImageUrl32 = GetImageUrl32(slit.typeID);
            //        summ.Items.Add(fh);
            //        diccHardware.Add(slit.typeID, fh);
            //    }
            //    fh.Units += slit.units;
            //    fh.Volume += slit.volume;

            //}

            //foreach (var shfit in sl.eshShoppingListFittings)
            //{
            //    foreach (var item in shfit.eshFitting.eshFittingHardwares)
            //    {
            //        EVFittingHardware fh = diccHardware.ContainsKey(item.typeID) ? diccHardware[item.typeID] : null;
            //        if (fh == null)
            //        {
            //            fh = new EVFittingHardware();
            //            fh.ItemID = item.typeID;
            //            fh.Name = item.invType.typeName;
            //            fh.ImageUrl32 = GetImageUrl32(item.invType.typeID);
            //            diccHardware.Add(item.typeID, fh);
            //            summ.Items.Add(fh);
            //        }
            //        fh.Units +=  item.units * shfit.units;
            //        fh.Volume += item.volume * shfit.units;
            //    }
            //}
            //return summ;
            
        }

        public int DeleteFitPorID(string publicID, int fittingID)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            logica.DeleteFitFromShoppingLIST(publicID, fittingID);
            return fittingID;
        }

        public EVFitting SetUnitsToFitInShoppingList(string publicID, int id, short units)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            EVFitting slf = logica.SetUnitsToFitInShoppingList(publicID, id, units, new Imagex32UrlResolver());
            return slf;
            //return MontarEVFiting(slf.eshFitting, slf.units);
        }

        public IEnumerable<EVFitting> SelectFitsEnShoppingList(string publicID){
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            IEnumerable<EVFitting> fitsSalida;

            fitsSalida = logica.SelectFitsInShoppingList(publicID, new Imagex32UrlResolver());

            return fitsSalida;
        }

        public MarketItem AddOrUpdateMarketItemEnShoppingList(string shoppingListPublidID, int itemID, short units)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            logica.UpdateMarketItemToShoppingList(shoppingListPublidID, itemID, units);
            return logica.SelectMarketItemByID(shoppingListPublidID, itemID, new Imagex32UrlResolver());
        }

        public void UpdateDeltaToSummary(string publicID, int itemID, short units)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            logica.UpdateDeltaToSummary(publicID, itemID, units);
        }

        public void ClearAllDeltaInSummary(string publicID)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            logica.ClearAllDeltaFromSummary(publicID);
        }


        public void DeleteMarketItemEnShoppingList(string shoppingListPublidID, int itemID)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            logica.DeleteItemFromShoppingList(shoppingListPublidID, itemID);

        }

        public IList<MarketItem> SelectMarketItemsEnShoppingList(string publicID)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            return logica.SelectMarketItemsEnShoppingList(publicID, new Imagex32UrlResolver());
        }

        #region eve-central

        public void UpdatePrices()
        {
            LogicaEveCentral logica = new LogicaEveCentral();
            logica.UpdatePrices();
        }

        #endregion


        private static EVFitting MontarEVFiting(eshFitting item, short units)
        {
            EVFitting fit = new EVFitting();
            fit.Description = item.description;
            fit.Name = item.name;
            fit.ShipName = item.invType.typeName;
            fit.ShipVolume = item.shipVolume;
            fit.Volume = item.volume;
            fit.ItemID = item.fittingID;
            fit.ImageUrl32 = GetImageUrl32(item.invType.typeID);
            fit.Units = units;
            foreach (var itemHwd in item.eshFittingHardwares)
            {
                EVFittingHardware hwd = new EVFittingHardware();
                hwd.Name = itemHwd.invType.typeName;
                hwd.Units = itemHwd.units;
                hwd.Volume = itemHwd.volume;
                hwd.ItemID = itemHwd.fittingHardwareID;
                hwd.ImageUrl32 = string.Format("http://image.eveonline.com/Type/{0}_32.png", itemHwd.invType.typeID);
                hwd.Slot = itemHwd.slotID;
                fit.FittingHardwares.Add(hwd);
            }
            return fit;
        }

        private static string GetImageUrl32(int typeId)
        {
            return string.Format("http://image.eveonline.com/Type/{0}_32.png", typeId);
        }
    }
}
