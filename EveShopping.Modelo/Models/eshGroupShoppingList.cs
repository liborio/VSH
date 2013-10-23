using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshGroupShoppingList
    {
        public eshGroupShoppingList()
        {
            this.eshGroupShoppingListSnapshots = new List<eshGroupShoppingListSnapshot>();
        }

        public int groupShoppingListID { get; set; }
        public int userID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string publicID { get; set; }
        public System.DateTime dateCreation { get; set; }
        public System.DateTime dateUpdate { get; set; }
        public int tradeHubID { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual eshTradeHub eshTradeHub { get; set; }
        public virtual ICollection<eshGroupShoppingListSnapshot> eshGroupShoppingListSnapshots { get; set; }
    }
}
