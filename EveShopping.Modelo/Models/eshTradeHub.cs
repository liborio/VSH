using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshTradeHub
    {
        public int solarSystemID { get; set; }
        public virtual mapSolarSystem mapSolarSystem { get; set; }
    }
}
