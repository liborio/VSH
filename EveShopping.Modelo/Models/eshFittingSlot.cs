using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshFittingSlot
    {
        public eshFittingSlot()
        {
            this.eshFittingHardwares = new List<eshFittingHardware>();
        }

        public int slotID { get; set; }
        public string name { get; set; }
        public virtual ICollection<eshFittingHardware> eshFittingHardwares { get; set; }
    }
}
