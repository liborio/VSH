using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshShoppingList
    {
        public eshShoppingList()
        {
            this.eshShoppingListFittings = new List<eshShoppingListFitting>();
            this.eshShoppingListInvTypes = new List<eshShoppingListInvType>();
        }

        public int shoppingListID { get; set; }
        public string publicID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime dateCreation { get; set; }
        public string readOnlypublicID { get; set; }
        public System.DateTime dateUpdate { get; set; }
        public int tradeHubID { get; set; }
        public System.DateTime dateAccess { get; set; }
        public bool allowEditForAll { get; set; }
        public Nullable<int> userID { get; set; }
        public virtual ICollection<eshShoppingListFitting> eshShoppingListFittings { get; set; }
        public virtual ICollection<eshShoppingListInvType> eshShoppingListInvTypes { get; set; }
        public virtual eshTradeHub eshTradeHub { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
