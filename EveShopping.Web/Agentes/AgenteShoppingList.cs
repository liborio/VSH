using EveShopping.Logica;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.Models;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Agentes
{
    public class AgenteShoppingList
    {
        public string CrearShoppingList(string name, string description)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            return logica.CrearShoppingList(name, description);
        }



        public EVFitting SelectFitPorID(int fittingID)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            eshFitting fit = logica.SelectFitPorID(fittingID);
            return MontarEVFiting(fit, 1);
        }

        public EVListSummary SelectListSummaryPorPublicID(string publicID)
        {
            LogicaShoppingLists logica = new LogicaShoppingLists();
            eshShoppingList sl = logica.SelectShoppingListByPublicID(publicID);

            EVListSummary summ = new EVListSummary();
            summ.Name = sl.name;
            summ.Description = sl.description;

            foreach (var slit in sl.eshShoppingListInvTypes)
            {
                EVFittingHardware fh = new EVFittingHardware();
                fh.Name = slit.invType.typeName;
                fh.Units = slit.units;
                fh.Volume = slit.volume;
                fh.ImageUrl32 = GetImageUrl32(slit.typeID);

                summ.Items.Add(fh);
            }
            return summ;
            
        }

        public int DeleteFitPorID(int fittingID)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            logica.DeleteFitPorID(fittingID);
            return fittingID;
        }

        public EVFitting SetUnitsToFitInShoppingList(string publicID, int id, short units)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            eshShoppingListFitting slf = logica.SetUnitsToFitInShoppingList(publicID, id, units);

            return MontarEVFiting(slf.eshFitting, slf.units);
        }

        public IEnumerable<EVFitting> SelectFitsEnShoppingList(string publicID){
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            IEnumerable<eshShoppingListFitting> listaEshF = logica.SelectFitsEnShoppingList(publicID);

            List<EVFitting> fitsSalida = new List<EVFitting>();

            foreach (var item in listaEshF)
            {
                EVFitting fit = MontarEVFiting(item.eshFitting, item.units);
                fitsSalida.Add(fit);
            }
            return fitsSalida;
        }

        public MarketItem AddOrUpdateMarketItemEnShoppingList(string shoppingListPublidID, int itemID, short units)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            logica.UpdateMarketItemToShoppingList(shoppingListPublidID, itemID, units);
            return logica.SelectMarketItemByID(shoppingListPublidID, itemID);
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
            return logica.SelectMarketItemsEnShoppingList(publicID);
        }

        private static EVFitting MontarEVFiting(eshFitting item, short units)
        {
            EVFitting fit = new EVFitting();
            fit.Description = item.description;
            fit.Name = item.name;
            fit.ShipName = item.invType.typeName;
            fit.ShipVolume = item.shipVolume;
            fit.Volume = item.volume;
            fit.FittingID = item.fittingID;
            fit.ShipImageUrl32 = GetImageUrl32(item.invType.typeID);
            fit.Units = units;
            foreach (var itemHwd in item.eshFittingHardwares)
            {
                EVFittingHardware hwd = new EVFittingHardware();
                hwd.Name = itemHwd.invType.typeName;
                hwd.Units = itemHwd.units;
                hwd.Volume = itemHwd.volume;
                hwd.FittingHardwareID = itemHwd.fittingHardwareID;
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
