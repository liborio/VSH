﻿using EveShopping.Modelo.EV;
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
            shot.publicID = Guid.NewGuid().ToString();
            shot.name = summ.Name;
            shot.description = summ.Description;
            
            foreach (var item in summ.Items)
            {
                if ((item.Units + item.Delta) > 0)
                {
                    eshSnapshotInvType shotitem = new eshSnapshotInvType();
                    shotitem.typeID = item.ItemID;
                    shotitem.unitPrice = item.UnitPrice;
                    shotitem.units = (short)item.Units;
                    shotitem.volume = item.Volume;
                    shot.eshSnapshotInvTypes.Add(shotitem);
                }
            }
            EveShoppingContext contexto = new EveShoppingContext();
            contexto.eshSnapshots.Add(shot);
            contexto.SaveChanges();

            return shot;
        }

        public IEnumerable<eshSnapshot> SelectStaticListsByShoppingListPublidID(string publicID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            var query =
                from sl in contexto.eshShoppingLists
                join ssl in contexto.eshSnapshots.Include("eshSnapshotInvTypes").Include("eshSnapshotInvTypes.invType") on sl.shoppingListID equals ssl.shoppingListID
                where sl.publicID == publicID
                orderby ssl.creationDate descending
                select ssl;

            return query.ToList();
        }

        public eshSnapshot SelectStaticListByPublicID(string publicID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            return contexto.eshSnapshots.Include("eshSnapshotInvTypes").Where(s => s.publicID == publicID).FirstOrDefault();
        }


    }

}
