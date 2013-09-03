using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class mapConstellation
    {
        public Nullable<int> regionID { get; set; }
        public int constellationID { get; set; }
        public string constellationName { get; set; }
        public Nullable<double> x { get; set; }
        public Nullable<double> y { get; set; }
        public Nullable<double> z { get; set; }
        public Nullable<double> xMin { get; set; }
        public Nullable<double> xMax { get; set; }
        public Nullable<double> yMin { get; set; }
        public Nullable<double> yMax { get; set; }
        public Nullable<double> zMin { get; set; }
        public Nullable<double> zMax { get; set; }
        public Nullable<int> factionID { get; set; }
        public Nullable<double> radius { get; set; }
    }
}
