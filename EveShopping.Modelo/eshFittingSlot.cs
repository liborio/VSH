using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class eshFittingSlot
    {
        public eshFittingSlot()
        {
            this.eshFittingHardwares = new List<eshFittingHardware>();
            this.eshFittings = new List<eshFitting>();
        }

        public int slotID { get; set; }
        public string name { get; set; }
        public virtual ICollection<eshFittingHardware> eshFittingHardwares { get; set; }
        public virtual ICollection<eshFitting> eshFittings { get; set; }
    }
}
