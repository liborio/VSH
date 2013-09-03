using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshShoppingList
    {
        public eshShoppingList()
        {
            this.eshShoppingListFittings = new List<eshShoppingListFitting>();
        }

        public int shoppingListID { get; set; }
        public string publicID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public System.DateTime dateCreation { get; set; }
        public System.DateTime dateUpdate { get; set; }
        public virtual ICollection<eshShoppingListFitting> eshShoppingListFittings { get; set; }
    }
}
