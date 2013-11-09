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
            shot.publicID = Guid.NewGuid().ToString();
            shot.name = summ.Name;
            shot.description = summ.Description;
            
            foreach (var item in summ.Items)
            {
                if ((item.Units) > 0)
                {
                    eshSnapshotInvType shotitem = new eshSnapshotInvType();
                    shotitem.typeID = item.ItemID;
                    shotitem.unitPrice = item.UnitPrice;
                    shotitem.units = item.Units;
                    shotitem.volume = item.Volume;
                    shot.eshSnapshotInvTypes.Add(shotitem);
                }
            }
            EveShoppingContext contexto = new EveShoppingContext();
            contexto.eshSnapshots.Add(shot);
            contexto.SaveChanges();

            return shot;
        }

        public void DeleteStaticShoppingList(eshSnapshot snap, string userName, EveShoppingContext contexto)
        {
            if (snap == null) throw new ApplicationException(Messages.err_staticShoppingListNoExiste);

            if (userName == null)
            {
                if (snap.eshShoppingList.userID.HasValue)
                {
                    throw new ApplicationException(Messages.err_notOwner);
                }
            }
            UserProfile user = contexto.userProfiles.Where(u => u.UserName == userName).FirstOrDefault();
            if (user == null) throw new ApplicationException(Messages.err_usuarioNoExiste);

            if (snap.eshShoppingList.userID.HasValue && snap.eshShoppingList.userID.Value != user.UserId)
            {
                throw new ApplicationException(Messages.err_notOwner);
            }


            Repositorios.RepositorioShoppingLists repo =
                new Repositorios.RepositorioShoppingLists(contexto);
            repo.ShoppingListUpdated(snap.eshShoppingList.shoppingListID);
            IEnumerable<eshSnapshotInvType> sit = snap.eshSnapshotInvTypes.Where(s => s.snapshotID == snap.snapshotID).ToList();
            foreach (var item in sit)
            {
                contexto.eshSnapshotInvTypes.Remove(item);
            }
            contexto.eshSnapshots.Remove(snap);
            contexto.SaveChanges();

        }

        public void DeleteStaticShoppingList(string staticPublicID, string userName)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshSnapshot snap = contexto.eshSnapshots.Where(s => s.publicID == staticPublicID).FirstOrDefault();
            DeleteStaticShoppingList(snap, userName, contexto);
        }


        public IEnumerable<EVStaticList> SelectStaticListsByShoppingListPublidID(string publicID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            var query =
                from sl in contexto.eshShoppingLists
                join ssl in contexto.eshSnapshots.Include("eshSnapshotInvTypes").Include("eshSnapshotInvTypes.invType") on sl.shoppingListID equals ssl.shoppingListID
                where sl.publicID == publicID
                orderby ssl.creationDate descending
                select new EVStaticList
                {
                    creationDate = ssl.creationDate,
                    description = ssl.description,
                    inGroupDate = null,
                    name = ssl.name,
                    ownerNick = null,
                    publicID = ssl.publicID,
                    shoppingListID = ssl.shoppingListID,
                    snapshotID = ssl.snapshotID,
                    totalPrice = ssl.totalPrice,
                    totalVolume = ssl.totalVolume
                };

            return query.ToList();
        }

        public eshSnapshot SelectStaticListByPublicID(string publicID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            return contexto.eshSnapshots.Include("eshSnapshotInvTypes").Where(s => s.publicID == publicID).FirstOrDefault();
        }


    }

}
