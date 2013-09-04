using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Modelo
{
    public class EVFittingHardware
    {
        public int FittingHardwareID { get; set; }
        public string Name { get; set; }
        public string ImageUrl32 { get; set; }
        public short Units { get; set; }
        public double Volume { get; set; }
        public int Slot {get; set;}
    }
}
