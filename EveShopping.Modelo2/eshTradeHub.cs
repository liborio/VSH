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
    
    public partial class eshTradeHub
    {
        public eshTradeHub()
        {
            this.eshGroupShoppingLists = new HashSet<eshGroupShoppingList>();
            this.eshShoppingLists = new HashSet<eshShoppingList>();
        }
    
        public int solarSystemID { get; set; }
    
        public virtual ICollection<eshGroupShoppingList> eshGroupShoppingLists { get; set; }
        public virtual ICollection<eshShoppingList> eshShoppingLists { get; set; }
        public virtual mapSolarSystem mapSolarSystem { get; set; }
    }
}