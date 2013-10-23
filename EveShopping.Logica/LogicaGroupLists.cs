using EveShopping.Modelo.EV;
using EveShopping.Modelo.Models;
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
        public string CreateGroupList(string userName, string name, string description)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            UserProfile up = contexto.userProfiles.Where(u => u.UserName == userName).FirstOrDefault();
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

        public void AddListToGroup(string groupPublicID, string listPublicID, string userName, string nick)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            eshGroupShoppingList sl;
            eshSnapshot snap;
            CommonTestGetForGroupShoppingListUpdate(groupPublicID, listPublicID, userName, contexto, out sl, out snap);

            eshGroupShoppingListSnapshot rel = new eshGroupShoppingListSnapshot();
            rel.groupShoppingListID = sl.groupShoppingListID;
            rel.nickName = nick;
            rel.snapshotID = snap.snapshotID;
            rel.creationDate = System.DateTime.Now;
            sl.dateUpdate = System.DateTime.Now;

            contexto.eshGroupShoppingListSnapshots.Add(rel);

            contexto.SaveChanges();
        }

        private static void CommonTestGetForGroupShoppingListUpdate(string groupPublicID, string listPublicID, string userName, EveShoppingContext contexto, out eshGroupShoppingList sl, out eshSnapshot snap)
        {
            sl = contexto.eshGroupShoppingLists.Include("").Where(s => s.publicID == groupPublicID).FirstOrDefault();
            if (sl == null) throw new ApplicationException(Messages.err_shoppingLisNoExiste);

            if (userName == null) throw new ApplicationException(Messages.err_notOwner);

            UserProfile user = contexto.userProfiles.Where(u => u.UserName == userName).FirstOrDefault();

            if (sl.userID != user.UserId) throw new ApplicationException(Messages.err_notOwner);

            LogicaSnapshots logicaSnap = new LogicaSnapshots();
            snap = logicaSnap.SelectStaticListByPublicID(listPublicID);

            if (snap == null) throw new ApplicationException(Messages.err_staticShoppingListNoExiste);
        }

        public EVListSummary SelectGroupListSummaryPorPublicID(string publicID, IImageResolver imageResolver)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            eshGroupShoppingList shoppingList = contexto.eshGroupShoppingLists.Where(sl => sl.publicID == publicID).FirstOrDefault();

            EVListSummary summary =
                new EVListSummary();
            summary.Description = shoppingList.description;
            summary.Name = shoppingList.name;
            summary.PublicID = shoppingList.publicID;
            summary.ReadOnlyPublicID = null;
            summary.ShoppingListID = shoppingList.groupShoppingListID;





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


        public void RemoveListFromGroup(string groupPublicID, string listPublicID, string userName)
        {
            EveShoppingContext contexto = new EveShoppingContext();

            eshGroupShoppingList sl;
            eshSnapshot snap;
            CommonTestGetForGroupShoppingListUpdate(groupPublicID, listPublicID, userName, contexto, out sl, out snap);

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

                UserProfile user = contexto.userProfiles.Where(u => u.UserName == userName).FirstOrDefault();

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

            UserProfile user = contexto.userProfiles.Where(u => u.UserName.ToLower() == userName.ToLower()).FirstOrDefault();

            if (user == null)
            {
                throw new ApplicationException(Messages.err_usuarioNoExiste);
            }

            var query = from u in contexto.userProfiles
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
