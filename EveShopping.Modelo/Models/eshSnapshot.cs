using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshSnapshot
    {
        public eshSnapshot()
        {
            this.eshGroupShoppingListSnapshots = new List<eshGroupShoppingListSnapshot>();
            this.eshSnapshotInvTypes = new List<eshSnapshotInvType>();
        }

        public int snapshotID { get; set; }
        public int shoppingListID { get; set; }
        public System.DateTime creationDate { get; set; }
        public double totalVolume { get; set; }
        public decimal totalPrice { get; set; }
        public string publicID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int? urlID { get; set; }
        public virtual eshTinyUrlMapping eshTinyUrlMapping { get; set; }
        public virtual ICollection<eshGroupShoppingListSnapshot> eshGroupShoppingListSnapshots { get; set; }
        public virtual eshShoppingList eshShoppingList { get; set; }
        public virtual ICollection<eshSnapshotInvType> eshSnapshotInvTypes { get; set; }
    }
}
