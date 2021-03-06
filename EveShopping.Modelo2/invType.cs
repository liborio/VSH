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
    
    public partial class invType
    {
        public invType()
        {
            this.eshFittingHardwares = new HashSet<eshFittingHardware>();
            this.eshFittings = new HashSet<eshFitting>();
            this.eshPrices = new HashSet<eshPrice>();
            this.eshShipsMarketGroups = new HashSet<eshShipsMarketGroup>();
            this.eshShoppingListInvTypes = new HashSet<eshShoppingListInvType>();
            this.eshShoppingListSummInvTypes = new HashSet<eshShoppingListSummInvType>();
            this.eshSnapshotInvTypes = new HashSet<eshSnapshotInvType>();
        }
    
        public int typeID { get; set; }
        public Nullable<int> groupID { get; set; }
        public string typeName { get; set; }
        public string description { get; set; }
        public Nullable<double> mass { get; set; }
        public Nullable<double> volume { get; set; }
        public Nullable<double> capacity { get; set; }
        public Nullable<int> portionSize { get; set; }
        public Nullable<byte> raceID { get; set; }
        public Nullable<decimal> basePrice { get; set; }
        public Nullable<bool> published { get; set; }
        public Nullable<int> marketGroupID { get; set; }
        public Nullable<double> chanceOfDuplicating { get; set; }
    
        public virtual ICollection<eshFittingHardware> eshFittingHardwares { get; set; }
        public virtual ICollection<eshFitting> eshFittings { get; set; }
        public virtual ICollection<eshPrice> eshPrices { get; set; }
        public virtual ICollection<eshShipsMarketGroup> eshShipsMarketGroups { get; set; }
        public virtual ICollection<eshShoppingListInvType> eshShoppingListInvTypes { get; set; }
        public virtual ICollection<eshShoppingListSummInvType> eshShoppingListSummInvTypes { get; set; }
        public virtual ICollection<eshSnapshotInvType> eshSnapshotInvTypes { get; set; }
    }
}
