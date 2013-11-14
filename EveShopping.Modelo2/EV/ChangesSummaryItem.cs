using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV
{
    public class ChangesSummaryItem
    {
        public double deltaVol { get; set; }
        public decimal deltaPrice { get; set; }
        public short delta { get; set; }
        public double vol { get; set; }
        public decimal price { get; set; }
        public short units { get; set; }
    }
}
