using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshShoppingListFitting
    {
        public int shoppingListID { get; set; }
        public int fittingID { get; set; }
        public short units { get; set; }
        public virtual eshFitting eshFitting { get; set; }
        public virtual eshShoppingList eshShoppingList { get; set; }
    }
}
