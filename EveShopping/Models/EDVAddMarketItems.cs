using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.Models;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVAddMarketItems : EDVShopingListBase
    {
        public IEnumerable<EVMarketItem> MarketItems { get; set; }
        public IEnumerable<invMarketGroup> MarketChain { get; set; }
        public IEnumerable<MarketItem> MarketItemsEnShoppingList { get; set; }

        public string GroupName { get; set; }
    }
}