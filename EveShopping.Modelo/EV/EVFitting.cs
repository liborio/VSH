﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV{
    public class EVFitting
    {
        public int FittingID {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShipName { get; set; }
        public double ShipVolume { get; set; }
        public short Units { get; set; }
        public double Volume { get; set; }
        public IList<EVFittingHardware> FittingHardwares { get; set; }
        public int ShipID { get; set; }
        public string ShipImageUrl32 { get; set; }
        public decimal ShipPrice { get; set; }
        public decimal Price { get; set; }
        public EVFitting()
        {
            FittingHardwares = new List<EVFittingHardware>();
        }
    }
}