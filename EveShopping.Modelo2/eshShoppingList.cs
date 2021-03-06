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
    
    public partial class eshShoppingList
    {
        public eshShoppingList()
        {
            this.eshShoppingListFittings = new HashSet<eshShoppingListFitting>();
            this.eshShoppingListInvTypes = new HashSet<eshShoppingListInvType>();
            this.eshShoppingListSummInvTypes = new HashSet<eshShoppingListSummInvType>();
            this.eshSnapshots = new HashSet<eshSnapshot>();
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
        public Nullable<int> urlID { get; set; }
    
        public virtual ICollection<eshShoppingListFitting> eshShoppingListFittings { get; set; }
        public virtual ICollection<eshShoppingListInvType> eshShoppingListInvTypes { get; set; }
        public virtual eshTinyUrlMapping eshTinyUrlMapping { get; set; }
        public virtual eshTradeHub eshTradeHub { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<eshShoppingListSummInvType> eshShoppingListSummInvTypes { get; set; }
        public virtual ICollection<eshSnapshot> eshSnapshots { get; set; }
    }
}
