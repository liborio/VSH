using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV
{
    public class BaseItem
    {
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        public int Units { get; set; }
        public string ImageUrl32 { get; set; }
        public int ItemID { get; set; }
        public double Volume { get; set; }
    }
}
