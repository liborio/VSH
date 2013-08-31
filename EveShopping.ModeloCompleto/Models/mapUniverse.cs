using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class mapUniverse
    {
        public int universeID { get; set; }
        public string universeName { get; set; }
        public Nullable<double> x { get; set; }
        public Nullable<double> y { get; set; }
        public Nullable<double> z { get; set; }
        public Nullable<double> xMin { get; set; }
        public Nullable<double> xMax { get; set; }
        public Nullable<double> yMin { get; set; }
        public Nullable<double> yMax { get; set; }
        public Nullable<double> zMin { get; set; }
        public Nullable<double> zMax { get; set; }
        public Nullable<double> radius { get; set; }
    }
}
