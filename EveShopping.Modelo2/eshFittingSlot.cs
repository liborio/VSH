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
    
    public partial class eshFittingSlot
    {
        public eshFittingSlot()
        {
            this.eshFittingHardwares = new HashSet<eshFittingHardware>();
        }
    
        public int slotID { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<eshFittingHardware> eshFittingHardwares { get; set; }
    }
}
