using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class mapLandmark
    {
        public short landmarkID { get; set; }
        public string landmarkName { get; set; }
        public string description { get; set; }
        public Nullable<int> locationID { get; set; }
        public Nullable<double> x { get; set; }
        public Nullable<double> y { get; set; }
        public Nullable<double> z { get; set; }
        public Nullable<double> radius { get; set; }
        public Nullable<int> iconID { get; set; }
        public Nullable<byte> importance { get; set; }
    }
}
