using EveShopping.Modelo.EV;
using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica
{
    public class LogicaSnapshots
    {
        public eshSnapshot CreateStaticShoppingList(string publicID, string name, IImageResolver iresolver){
            LogicaShoppingLists logica =
                new LogicaShoppingLists();

            EVListSummary summ = logica.SelectListSummaryPorPublicID(publicID, iresolver);

            eshSnapshot shot = new eshSnapshot();
            shot.creationDate = System.DateTime.Now;
            shot.shoppingListID = summ.ShoppingListID;
            shot.totalPrice = summ.TotalPrice;
            shot.totalVolume = summ.TotalVolume;
            
            foreach (var item in summ.Items)
            {
                eshSnapshotInvType shotitem = new eshSnapshotInvType();
		        shotitem.typeID = item.ItemID;
                shotitem.unitPrice = item.UnitPrice;
                shotitem.units = (short)item.Units;
                shotitem.volume = item.Volume;       
                shot.eshSnapshotInvTypes.Add(shotitem);
            }
            EveShoppingContext contexto = new EveShoppingContext();
            contexto.eshSnapshots.Add(shot);
            contexto.SaveChanges();

            return shot;
        }
    }
}
