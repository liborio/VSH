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
    
    public partial class eshFittingHardware
    {
        public int fittingHardwareID { get; set; }
        public int fittingID { get; set; }
        public int typeID { get; set; }
        public int slotID { get; set; }
        public short positionInSlot { get; set; }
        public int units { get; set; }
        public double volume { get; set; }
    
        public virtual eshFitting eshFitting { get; set; }
        public virtual eshFittingSlot eshFittingSlot { get; set; }
        public virtual invType invType { get; set; }
    }
}
