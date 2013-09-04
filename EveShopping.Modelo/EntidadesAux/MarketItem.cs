using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EntidadesAux
{
    public class MarketItem
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string URI { get; set; }
        public short Units { get; set; }
        public double Volume { get; set; }
    }
}
