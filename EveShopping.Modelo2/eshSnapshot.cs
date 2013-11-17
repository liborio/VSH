//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EveShopping.Modelo
{
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    
    public partial class eshSnapshot
    {
        public eshSnapshot()
        {
            this.eshGroupShoppingListSnapshots = new HashSet<eshGroupShoppingListSnapshot>();
            this.eshSnapshotInvTypes = new HashSet<eshSnapshotInvType>();
        }
    
        public int snapshotID { get; set; }
        public int shoppingListID { get; set; }
        public System.DateTime creationDate { get; set; }
        public double totalVolume { get; set; }
        public decimal totalPrice { get; set; }
        public string publicID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<int> urlID { get; set; }
    
        public virtual ICollection<eshGroupShoppingListSnapshot> eshGroupShoppingListSnapshots { get; set; }
        public virtual eshShoppingList eshShoppingList { get; set; }
        public virtual eshTinyUrlMapping eshTinyUrlMapping { get; set; }
        public virtual ICollection<eshSnapshotInvType> eshSnapshotInvTypes { get; set; }
    }
}