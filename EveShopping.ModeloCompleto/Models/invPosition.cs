using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invPosition
    {
        public long itemID { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public Nullable<float> yaw { get; set; }
        public Nullable<float> pitch { get; set; }
        public Nullable<float> roll { get; set; }
    }
}
