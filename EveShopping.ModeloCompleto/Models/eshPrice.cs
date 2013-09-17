using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshPrice
    {
        public int typeID { get; set; }
        public int solarSystemID { get; set; }
        public double ecPrice { get; set; }
        public System.DateTime updateTime { get; set; }
        public virtual invType invType { get; set; }
        public virtual mapSolarSystem mapSolarSystem { get; set; }
    }
}
