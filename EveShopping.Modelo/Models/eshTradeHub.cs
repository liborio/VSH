using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshTradeHub
    {
        public eshTradeHub()
        {
            this.eshShoppingLists = new List<eshShoppingList>();
        }

        public int solarSystemID { get; set; }
        public virtual ICollection<eshShoppingList> eshShoppingLists { get; set; }
        public virtual mapSolarSystem mapSolarSystem { get; set; }
    }
}
