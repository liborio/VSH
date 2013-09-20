using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EveShopping.Web.Modelo
{
    public class EVFittingHardware
    {
        [ScriptIgnore]
        public int FittingHardwareID { get; set; }
        public string ImageUrl32 { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public double Volume { get; set; }
        [ScriptIgnore]
        public int Slot { get; set; }
        [ScriptIgnore]
        public string Size { get; set; }
        [ScriptIgnore]
        public string GroupName { get; set; }
        [ScriptIgnore]
        public string SlotName { get; set; }
    }
}
