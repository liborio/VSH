using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshFittingHardware
    {
        public int fittingHardwareID { get; set; }
        public int fittingID { get; set; }
        public int typeID { get; set; }
        public int slotID { get; set; }
        public short positionInSlot { get; set; }
        public virtual eshFitting eshFitting { get; set; }
        public virtual eshFittingSlot eshFittingSlot { get; set; }
    }
}
