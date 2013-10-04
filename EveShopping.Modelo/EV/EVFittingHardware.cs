using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV
{
    public class EVFittingHardware : BaseItem
    {
        public int Slot { get; set; }
        public string Size { get; set; }
        public string GroupName { get; set; }
        public string SlotName { get; set; }
    }
}
