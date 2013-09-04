using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshShoppingListInvType
    {
        public int shoppingListID { get; set; }
        public int typeID { get; set; }
        public short units { get; set; }
        public double volume { get; set; }
        public virtual eshShoppingList eshShoppingList { get; set; }
        public virtual invType invType { get; set; }
    }
}
