using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshShoppingList
    {
        public eshShoppingList()
        {
            this.eshFittings = new List<eshFitting>();
        }

        public int shoppingListID { get; set; }
        public string publicID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public virtual ICollection<eshFitting> eshFittings { get; set; }
    }
}
