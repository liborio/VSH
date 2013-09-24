﻿using EveShopping.Comun;
using EveShopping.Logica.EveCentral;
using EveShopping.Modelo.Models;
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

            IEnumerable<invType> items =
                contexto.invTypes.Where(t => t.marketGroupID != null).ToList();

            List<int> ItemIds = new List<int>();
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
                        IEnumerable<ItemPrice> prices = agente.GetPrices(ItemIds, hubIdList);
                        foreach (var price in prices)
                        {
                            eshPrice eprice = contexto.eshPrices.Where(p => p.typeID == price.ItemID && p.solarSystemID == price.HubID).FirstOrDefault();
                            if (eprice == null)
                            {
                                eprice = new eshPrice();
                                contexto.eshPrices.Add(eprice);
                                eprice.typeID = price.ItemID;
                                eprice.solarSystemID = price.HubID;
                            }
                            eprice.avg = price.Stats.Avg;
                            eprice.max = price.Stats.Max;
                            eprice.min = price.Stats.Min;
                            eprice.median = price.Stats.Median;
                            eprice.updateTime = System.DateTime.Now;
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