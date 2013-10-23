using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshGroupShoppingListSnapshot
    {
        public int groupShoppingListID { get; set; }
        public int snapshotID { get; set; }
        public string nickName { get; set; }
        public System.DateTime creationDate { get; set; }
        public virtual eshGroupShoppingList eshGroupShoppingList { get; set; }
        public virtual eshSnapshot eshSnapshot { get; set; }
    }
}
