using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshShoppingListSummInvType
    {
        public int shoppingListID { get; set; }
        public int typeID { get; set; }
        public int delta { get; set; }
        public virtual eshShoppingList eshShoppingList { get; set; }
        public virtual invType invType { get; set; }
    }
}
