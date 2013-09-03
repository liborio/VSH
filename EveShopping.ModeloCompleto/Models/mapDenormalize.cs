using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class mapDenormalize
    {
        public int itemID { get; set; }
        public Nullable<int> typeID { get; set; }
        public Nullable<int> groupID { get; set; }
        public Nullable<int> solarSystemID { get; set; }
        public Nullable<int> constellationID { get; set; }
        public Nullable<int> regionID { get; set; }
        public Nullable<int> orbitID { get; set; }
        public Nullable<double> x { get; set; }
        public Nullable<double> y { get; set; }
        public Nullable<double> z { get; set; }
        public Nullable<double> radius { get; set; }
        public string itemName { get; set; }
        public Nullable<double> security { get; set; }
        public Nullable<byte> celestialIndex { get; set; }
        public Nullable<byte> orbitIndex { get; set; }
    }
}
