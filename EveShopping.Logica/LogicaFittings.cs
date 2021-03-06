﻿using EveShopping.Logica.QEntities;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.EV;
using EveShopping.Modelo;
using EveShopping.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EveShopping.Logica
{
    public class LogicaFittings
    {
        public void DeleteFitting(int fittingID, string userName)
        {
            EveShoppingContext context = new EveShoppingContext();


            using (TransactionScope scope = new TransactionScope())
            {
                eshFitting fit = context.eshFittings.Where(f => f.fittingID == fittingID).FirstOrDefault();
                if (fit == null) throw new ApplicationException(Messages.err_fittingNoExiste);
                UserProfile up = context.UserProfiles.Where(u => u.UserName == userName).FirstOrDefault();
                if (up == null) throw new ApplicationException(Messages.err_usuarioNoExiste);
                if (fit.userID.HasValue && fit.userID != up.UserId) throw new ApplicationException(Messages.err_notOwner);

                //if fitting is used in any shopping list, we cant completly remove it, will just not relate to this user
                if (fit.eshShoppingListFittings.Count >= 0)
                {
                    fit.userID = null;
                }
                //else, the fitting is not used, we can delete it completly
                else
                {
                    IEnumerable<eshFittingHardware> fithwds = fit.eshFittingHardwares.ToList();
                    foreach (var item in fithwds)
                    {
                        context.eshFittingHardwares.Remove(item);
                    }
                    context.eshFittings.Remove(fit);
                }
                context.SaveChanges();
                scope.Complete();
            }

        }


        public int GetFittingCountByUser(string userName)
        {
                        EveShoppingContext contexto = new EveShoppingContext();
            var count =
                (from f in contexto.eshFittings
                join u in contexto.UserProfiles on f.userID equals u.UserId
                where u.UserName == userName
                select f.fittingID).Count();
            return count;

        }

        public IEnumerable<ShipMarketGroup> SelectMarketGroupsByParentID(int parentID, string userName)
        {

            EveShoppingContext contexto = new EveShoppingContext();

            //Get the ships contained in user fittings
            var queryShips = (from it in contexto.invTypes.Include("invMarketGroups")
                             join f in contexto.eshFittings on it.typeID equals f.shipTypeID
                             join u in contexto.UserProfiles on f.userID equals u.UserId
                             where u.UserName == userName
                             select it.typeID).Distinct().ToList();

            var queryGroups = (from g in contexto.invMarketGroups
                               join sg in contexto.eshShipsMarketGroups on g.marketGroupID equals sg.marketGroupID
                               where queryShips.Contains(sg.typeID) && parentID == g.parentGroupID
                               select g).Distinct();


            //Get the number of ships in each group and prepare the final list
            List<ShipMarketGroup> lista = new List<ShipMarketGroup>();
            foreach (var item in queryGroups)
            {
                var queryUnits = (from it in contexto.eshShipsMarketGroups
                                  join f in contexto.eshFittings on it.typeID equals f.shipTypeID
                                    join u in contexto.UserProfiles on f.userID equals u.UserId
                                  where it.marketGroupID == item.marketGroupID && u.UserName == userName
                                  select it.typeID).Count();
                ShipMarketGroup smg = new ShipMarketGroup
                {
                    marketGroupID = item.marketGroupID,
                    name = item.marketGroupName,
                    units = queryUnits
                };
                lista.Add(smg);
            }

            return lista;
        }

        public IEnumerable<EVFitting> SelectFitsByMarketGroup(string userName, int marketGroupID, IImageResolver imageResolver, int tradeHubID)
        {
            EveShoppingContext contexto =
    new EveShoppingContext();
            var qfittings =
                (from f in contexto.eshFittings 
                 join it in contexto.invTypes on f.shipTypeID equals it.typeID
                 join mg in contexto.invMarketGroups on it.marketGroupID equals mg.marketGroupID
                 join p in contexto.eshPrices on new { tradeHubID, it.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                 join u in contexto.UserProfiles on f.userID equals u.UserId
                 where u.UserName == userName && it.marketGroupID == marketGroupID
                 select new QFitting
                 {
                     Description = f.description,
                     PublicID = f.publicID,
                     FittingID = f.fittingID,
                     Name = f.name,
                     ShipID = f.shipTypeID.Value,
                     ShipName = f.invType.typeName,
                     ShipVolume = f.shipVolume,
                     Units = 1,
                     ShipPrice = p.avg,
                     Price = p.avg,
                     Volume = f.shipVolume,
                     InvType = it
                 });
            
            return MountFittingCommon(contexto, qfittings, imageResolver, tradeHubID);
        }

        public int GetFitMarketGroupID(int fitID)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            var groupID =
                (from f in contexto.eshFittings
                 where f.fittingID == fitID
                 select f.invType.marketGroupID).FirstOrDefault();

            return groupID.Value;
        }

        internal IEnumerable<EVFitting> MountFittingCommon(EveShoppingContext contexto, IEnumerable<QFitting> qfittings, IImageResolver imageResolver, int tradeHubID)
        {

            List<EVFitting> fittings = new List<EVFitting>();
            foreach (var qfit in qfittings)
            {
                if (string.IsNullOrEmpty(qfit.PublicID)) { qfit.PublicID = Guid.NewGuid().ToString(); }
                EVFitting fit = new EVFitting
                {
                    Description = qfit.Description,
                    PublicID = qfit.PublicID,
                    ItemID = qfit.FittingID,
                    Name = qfit.Name,
                    ShipID = qfit.ShipID,
                    ShipName = qfit.ShipName,
                    ShipVolume = qfit.ShipVolume,
                    Units = qfit.Units,
                    ShipPrice = qfit.ShipPrice,
                    TotalPrice = qfit.Price,
                };

                fit.ImageUrl32 = imageResolver != null ? imageResolver.GetImageURL(qfit.ShipID) : string.Empty; ;
                fit.ShipVolume = RepositorioItems.GetVolume(qfit.InvType);
                fit.Volume = fit.ShipVolume * fit.Units;
                fittings.Add(fit);



                AddFittingHardwaresToFitting(contexto, imageResolver, tradeHubID, fit);
            }

            return fittings;

        }

        public void AddFittingHardwaresToFitting(EveShoppingContext contexto, IImageResolver imageResolver, int tradeHubID, EVFitting fit)
        {
            var qfittingHardwares =
               (from f in contexto.eshFittings
                join fh in contexto.eshFittingHardwares on f.fittingID equals fh.fittingID
                join it in contexto.invTypes on fh.typeID equals it.typeID
                join mg in contexto.invMarketGroups on it.marketGroupID equals mg.marketGroupID
                join p in contexto.eshPrices on new { tradeHubID, it.typeID } equals new { tradeHubID = p.solarSystemID, p.typeID }
                where f.fittingID == fit.ItemID
                orderby fh.slotID, fh.positionInSlot, fh.invType.typeName
                select new EVFittingHardware
                {
                    ItemID = fh.typeID,
                    GroupName = mg.marketGroupName,
                    Name = it.typeName,
                    TotalPrice = fh.units * p.avg,
                    UnitPrice = p.avg,
                    Slot = fh.slotID,
                    SlotName = fh.eshFittingSlot.name,
                    Units = fh.units,
                    Volume = fh.units * it.volume.Value

                });
            foreach (var item in qfittingHardwares)
            {
                item.ImageUrl32 = imageResolver!=null? imageResolver.GetImageURL(item.ItemID):string.Empty;
                fit.FittingHardwares.Add(item);
                fit.TotalPrice += item.TotalPrice * fit.Units;
                fit.Volume += item.Volume * fit.Units;
            }
        }
    }
}
