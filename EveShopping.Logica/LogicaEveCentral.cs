using EveShopping.Comun;
using EveShopping.Logica.EveCentral;
using EveShopping.Modelo;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica
{
    public class LogicaEveCentral
    {
        public void UpdatePrices()
        {
            EveShoppingContext contexto = new EveShoppingContext();
            List<int> hubIdList = new List<int>();
            foreach (var hub in contexto.eshTradeHubs)
            {
                hubIdList.Add(hub.solarSystemID);
            }
            EveCentralAgent agente = new EveCentralAgent();
            int[] categoryIDs = new int[]{6,7,8,18,32};



            var items =
                (from it in contexto.invTypes
                 join ig in contexto.invGroups on it.groupID equals ig.groupID
                 where it.marketGroupID != null //&&  ig.categoryID != null &&categoryIDs.Contains(ig.categoryID.Value)
                 select new { typeID = it.typeID }).ToList();
               // contexto.invTypes.Where(t => t.marketGroupID != null && categoryIDs.Contains(t. ).ToList();

            List<int> ItemIds = new List<int>();

            foreach (var hub in hubIdList)
            {
                int[] singlehubList = new int[] { hub };

                foreach (var item in items)
                {
                    try
                    {

                        if (ItemIds.Count <= 10)
                        {
                            ItemIds.Add(item.typeID);
                        }
                        else
                        {
                            ItemIds.Add(item.typeID);
                            IEnumerable<ItemPrice> prices = agente.GetPrices(ItemIds, singlehubList);
                            foreach (var price in prices)
                            {
                                eshPrice eprice = contexto.eshPrices.Where(p => p.typeID == price.ItemID && p.solarSystemID == price.HubID).FirstOrDefault();

                                
                                if (eprice == null)
                                {
                                    eprice = new eshPrice();
                                    contexto.eshPrices.Add(eprice);
                                    eprice.typeID = price.ItemID;
                                    eprice.solarSystemID = price.HubID;
                                    //if stats are null for this item means that the price update failed for it
                                    if (price.Stats == null)
                                    {
                                        eprice.avg = 0;
                                        eprice.updateTime = System.DateTime.Now;
                                    }
                                }
                                if (price.Stats != null)
                                {
                                    eprice.avg = price.Stats.Avg;
                                    eprice.updateTime = System.DateTime.Now;
                                }
                            }
                            ItemIds.Clear();
                            contexto.SaveChanges();
                        }

                    }
                    catch (Exception ex)
                    {
                        Logging.Logger.Error(string.Format("Error recuperando precios"));
                        Logging.Logger.Error(ex.ToString());
                    }
                }
            }

        }
    }
}
