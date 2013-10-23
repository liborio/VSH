using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshTradeHub
    {
        public eshTradeHub()
        {
            this.eshGroupShoppingLists = new List<eshGroupShoppingList>();
            this.eshShoppingLists = new List<eshShoppingList>();
        }

        public int solarSystemID { get; set; }
        public virtual ICollection<eshGroupShoppingList> eshGroupShoppingLists { get; set; }
        public virtual ICollection<eshShoppingList> eshShoppingLists { get; set; }
        public virtual mapSolarSystem mapSolarSystem { get; set; }
    }
}
