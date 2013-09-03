using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class chrFaction
    {
        public int factionID { get; set; }
        public string factionName { get; set; }
        public string description { get; set; }
        public Nullable<int> raceIDs { get; set; }
        public Nullable<int> solarSystemID { get; set; }
        public Nullable<int> corporationID { get; set; }
        public Nullable<double> sizeFactor { get; set; }
        public Nullable<short> stationCount { get; set; }
        public Nullable<short> stationSystemCount { get; set; }
        public Nullable<int> militiaCorporationID { get; set; }
        public Nullable<int> iconID { get; set; }
    }
}
