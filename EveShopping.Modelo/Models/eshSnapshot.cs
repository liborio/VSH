using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshSnapshot
    {
        public eshSnapshot()
        {
            this.eshSnapshotInvTypes = new List<eshSnapshotInvType>();
        }

        public int snapshotID { get; set; }
        public Nullable<int> shoppingListID { get; set; }
        public System.DateTime creationDate { get; set; }
        public double totalVolume { get; set; }
        public decimal totalPrice { get; set; }
        public virtual eshShoppingList eshShoppingList { get; set; }
        public virtual ICollection<eshSnapshotInvType> eshSnapshotInvTypes { get; set; }
    }
}
