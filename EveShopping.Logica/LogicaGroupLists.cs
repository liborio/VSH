using EveShopping.Modelo.EV;
using EveShopping.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EveShopping.Logica
{
    public class LogicaGroupLists
    {
        public bool IsListOwner(string publicID, string userName)
        {
            if (userName == null) return false;

            EveShoppingContext contexto = new EveShoppingContext();

            var query = from g in contexto.eshGroupShoppingLists
                        join u in contexto.UserProfiles on g.userID equals u.UserId
                        where u.UserName == userName && g.publicID == publicID
                        select g.groupShoppingListID;

            return query.Count() > 0;
        }

        public string CreateGroupList(string userName, string name, string description)        
        {
            try
            {
                EveShoppingContext contexto = new EveShoppingContext();

                UserProfile up = contexto.UserProfiles.Where(u => u.UserName == userName).FirstOrDefault();
                if (up == null) throw new ApplicationException(Messages.err_usuarioNoExiste);

                eshGroupShoppingList group =
                    new eshGroupShoppingList();
                group.dateCreation = DateTime.Now;
                group.dateUpdate = DateTime.Now;
                group.name = name;
                group.description = description;
                group.publicID = Guid.NewGuid().ToString();
                group.tradeHubID = 30000142;
                group.userID = up.UserId;

                contexto.eshGroupShoppingLists.Add(group);
                contexto.SaveChanges();

                return group.publicID;
            }
            catch (Exception ex)
            {
                throw; 
            }

        }

        public IEnumerable<EVStaticList> SelectStaticListsHeadersByGroupId(string groupID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            var query = from ssl in contexto.eshSnapshots
                        join gs in contexto.eshGroupShoppingListSnapshots on ssl.snapshotID equals gs.snapshotID
                        join g in contexto.eshGroupShoppingLists on gs.groupShoppingListID equals g.groupShoppingListID
                        where g.publicID == groupID
                        select new EVStaticList
                        {
                            creationDate = ssl.creationDate,
                            description = ssl.description,
                            inGroupDate = gs.creationDate,
                            name = ssl.name,
                            ownerNick = gs.nickName,
                            publicID = ssl.publicID,
                            shoppingListID = ssl.shoppingListID,
                            snapshotID = ssl.snapshotID,
                            totalPrice = ssl.totalPrice,
                            totalVolume = ssl.totalVolume
                        };
            return query.ToList();
        }

        public EVStaticList SelectStaticListHeaderById(string groupID, string publicID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            var query = from ssl in contexto.eshSnapshots
                        join gs in contexto.eshGroupShoppingListSnapshots on ssl.snapshotID equals gs.snapshotID
                        join g in contexto.eshGroupShoppingLists on gs.groupShoppingListID equals g.groupShoppingListID
                        where ssl.publicID == publicID && g.publicID == groupID
                        select new EVStaticList
                        {
                            creationDate = ssl.creationDate,
                            description = ssl.description,
                            inGroupDate = gs.creationDate,
                            name = ssl.name,
                            ownerNick = gs.nickName,
                            publicID = ssl.publicID,
                            shoppingListID = ssl.shoppingListID,
                            snapshotID = ssl.snapshotID,
                            totalPrice = ssl.totalPrice,
                            totalVolume = ssl.totalVolume
                        };
            return query.FirstOrDefault();

        }

        public void ActualizarGroupListHeader(string publicID, string userName, string name, string description)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            eshGroupShoppingList gsl;

            CommonTestGetForGroupShoppingListUpdate(publicID, userName, contexto, out gsl);

            gsl.name = name;
            gsl.description = description;
            gsl.dateUpdate = DateTime.Now;
            contexto.SaveChanges();
        }

        public string AddListToGroup(string groupPublicID, string listPublicID, string userName, string nick, IImageResolver resolver = null)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            string snapPublicID = null;

            eshGroupShoppingList sl;
            eshSnapshot snap;
            CommonTestGetForGroupShoppingListUpdate(groupPublicID, listPublicID, userName, contexto, out sl);

            LogicaSnapshots logicaSnap = new LogicaSnapshots();

            snap = logicaSnap.SelectStaticListByPublicID(listPublicID);
            //if not snapshot, we check if it is a normal list
            if (snap == null)
            {
                snap = logicaSnap.CreateStaticShoppingList(listPublicID, null, resolver);
            }
            // if not snapshot, we check if it is a group list
            //if (snap == null)
            //{

            //    snap = logicaSnap.CreateStaticShoppingListFromGroup(listPublicID, null, resolver);
            //}
            if (snap == null) throw new ApplicationException(Messages.err_staticShoppingListNoExiste);


            eshGroupShoppingListSnapshot rel = new eshGroupShoppingListSnapshot();
            rel.groupShoppingListID = sl.groupShoppingListID;
            rel.nickName = nick;
            rel.snapshotID = snap.snapshotID;
            rel.creationDate = System.DateTime.Now;
            sl.dateUpdate = System.DateTime.Now;

            contexto.eshGroupShoppingListSnapshots.Add(rel);

            contexto.SaveChanges();

            return snap.publicID;
        }

        private static void CommonTestGetForGroupShoppingListUpdate(string groupPublicID, string userName, EveShoppingContext contexto, out eshGroupShoppingList sl)
        {
            sl = contexto.eshGroupShoppingLists.Where(s => s.publicID == groupPublicID).FirstOrDefault();
            if (sl == null) throw new ApplicationException(Messages.err_shoppingLisNoExiste);

            if (userName == null) throw new ApplicationException(Messages.err_notOwner);

            UserProfile user = contexto.UserProfiles.Where(u => u.UserName == userName).FirstOrDefault();

            if (sl.userID != user.UserId) throw new ApplicationException(Messages.err_notOwner);
        }


        private static void CommonTestGetForGroupShoppingListUpdate(string groupPublicID, string listPublicID, string userName, EveShoppingContext contexto, out eshGroupShoppingList sl)
        {
            CommonTestGetForGroupShoppingListUpdate(groupPublicID, userName, contexto, out sl);

        }

        public EVListSummary SelectGroupListSummaryPorPublicID(string publicID, IImageResolver imageResolver)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshGroupShoppingList shoppingList = contexto.eshGroupShoppingLists.Where(sl => sl.publicID == publicID).FirstOrDefault();

            if (shoppingList == null) { return null; }

            EVListSummary summary =
                new EVListSummary();
            summary.Description = shoppingList.description;
            summary.Name = shoppingList.name;
            summary.PublicID = shoppingList.publicID;
            summary.ReadOnlyPublicID = null;
            summary.ShoppingListID = shoppingList.groupShoppingListID;

            Dictionary<int, EVFittingHardware> diccHwd = new Dictionary<int, EVFittingHardware>();

            //por cada snapshot que tenemos asociado
            foreach (var snapshot in shoppingList.eshGroupShoppingListSnapshots)
            {
                summary.TotalVolume += snapshot.eshSnapshot.totalVolume;
                foreach (var item in snapshot.eshSnapshot.eshSnapshotInvTypes)
                {
                    EVFittingHardware efth = null;
                    if (diccHwd.ContainsKey(item.typeID))
                    {
                        efth = diccHwd[item.typeID];
                        efth.Volume += item.volume.Value;
                        efth.TotalPrice += item.unitPrice * item.units;
                        efth.Units += item.units;
                    }
                    else
                    {
                        efth = new EVFittingHardware()
                        {
                            Name = item.invType.typeName,
                            ItemID = item.typeID,
                            Units = item.units,
                            Volume = item.volume.Value,
                            UnitVolume = item.volume.Value / item.units,
                            TotalPrice = item.unitPrice * item.units,
                            UnitPrice = item.unitPrice,
                            ImageUrl32 = imageResolver.GetImageURL(item.typeID)
                        };
                        diccHwd.Add(efth.ItemID, efth);

                    }                   
                }
            }
            
            foreach (var item in diccHwd.Values)
            {
                summary.Items.Add(item);
            }
            return summary;

        }


        public void RemoveListFromGroup(string groupPublicID, string listPublicID, string userName)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            eshGroupShoppingList sl;
            eshSnapshot snap;
            CommonTestGetForGroupShoppingListUpdate(groupPublicID, listPublicID, userName, contexto, out sl);

            LogicaSnapshots logicaSnap = new LogicaSnapshots();
            snap = logicaSnap.SelectStaticListByPublicID(listPublicID);
            if (snap == null) { throw new ApplicationException(Messages.err_staticShoppingListNoExiste); }


            eshGroupShoppingListSnapshot gsls = contexto.eshGroupShoppingListSnapshots.Where(gs => gs.snapshotID == snap.snapshotID && gs.groupShoppingListID == sl.groupShoppingListID).FirstOrDefault();

            if (gsls == null) throw new ApplicationException();

            contexto.eshGroupShoppingListSnapshots.Remove(gsls);
            contexto.SaveChanges();
        }



        public void DeleteGroupList(string userName, string publicID)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            using (TransactionScope scope = new TransactionScope())
            {


                eshGroupShoppingList sl = contexto.eshGroupShoppingLists.Where(s => s.publicID == publicID).FirstOrDefault();
                if (sl == null) throw new ApplicationException(Messages.err_shoppingLisNoExiste);

                if (userName == null) throw new ApplicationException(Messages.err_notOwner);

                UserProfile user = contexto.UserProfiles.Where(u => u.UserName == userName).FirstOrDefault();

                if (sl.userID != user.UserId) throw new ApplicationException(Messages.err_notOwner);

                //passed the user right test, the shopping list can be deleted based on the owner.

                //At this moment we dont make any further test regarding if the list used or not, it is possible to delete only based on the ownership.

                //Delete the related static lists
                List<eshGroupShoppingListSnapshot> listSnapshots = sl.eshGroupShoppingListSnapshots.ToList();
                foreach (var snp in listSnapshots)
                {
                    contexto.eshGroupShoppingListSnapshots.Remove(snp);
                }
                contexto.eshGroupShoppingLists.Remove(sl);

                contexto.SaveChanges();
                scope.Complete();
            }

        }


        public IList<EVShoppingListHeader> SelectGroupListsByUserName(string userName)
        {
            EveShoppingContext contexto =
                new EveShoppingContext();

            UserProfile user = contexto.UserProfiles.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefault();

            if (user == null)
            {
                throw new ApplicationException(Messages.err_usuarioNoExiste);
            }

            var query = from u in contexto.UserProfiles
                        join sl in contexto.eshGroupShoppingLists on u.UserId equals sl.userID
                        where u.UserName == userName
                        select new EVShoppingListHeader
                        {
                            dateCreation = sl.dateCreation,
                            dateUpdate = sl.dateUpdate,
                            name = sl.name,
                            publicID = sl.publicID,
                            staticCount = sl.eshGroupShoppingListSnapshots.Count
                        };
            return query.ToList();

        }

    }
}
