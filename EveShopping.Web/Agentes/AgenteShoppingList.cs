using EveShopping.Logica;
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
        public EVFitting SelectFitPorID(int fittingID)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            eshFitting fit = logica.SelectFitPorID(fittingID);
            return MontarEVFiting(fit);
        }

        public int DeleteFitPorID(int fittingID)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            logica.DeleteFitPorID(fittingID);
            return fittingID;
        }

        public IEnumerable<EVFitting> SelectFitsEnShoppingList(string publicID){
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            IEnumerable<eshFitting> listaEshF = logica.SelectFitsEnShoppingList(publicID);

            List<EVFitting> fitsSalida = new List<EVFitting>();

            foreach (var item in listaEshF)
            {
                EVFitting fit = MontarEVFiting(item);
                fitsSalida.Add(fit);
            }

            return fitsSalida;
        }

        private static EVFitting MontarEVFiting(eshFitting item)
        {
            EVFitting fit = new EVFitting();
            fit.Description = item.description;
            fit.Name = item.name;
            fit.ShipName = item.invType.typeName;
            fit.ShipVolume = item.shipVolume;
            fit.Volume = item.volume;
            fit.FittingID = item.fittingID;
            fit.ShipImageUrl32 = string.Format("http://image.eveonline.com/Type/{0}_32.png", item.invType.typeID);
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
    }
}
