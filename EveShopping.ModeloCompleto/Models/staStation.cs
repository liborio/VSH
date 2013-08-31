using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class staStation
    {
        public int stationID { get; set; }
        public Nullable<short> security { get; set; }
        public Nullable<double> dockingCostPerVolume { get; set; }
        public Nullable<double> maxShipVolumeDockable { get; set; }
        public Nullable<int> officeRentalCost { get; set; }
        public Nullable<byte> operationID { get; set; }
        public Nullable<int> stationTypeID { get; set; }
        public Nullable<int> corporationID { get; set; }
        public Nullable<int> solarSystemID { get; set; }
        public Nullable<int> constellationID { get; set; }
        public Nullable<int> regionID { get; set; }
        public string stationName { get; set; }
        public Nullable<double> x { get; set; }
        public Nullable<double> y { get; set; }
        public Nullable<double> z { get; set; }
        public Nullable<double> reprocessingEfficiency { get; set; }
        public Nullable<double> reprocessingStationsTake { get; set; }
        public Nullable<byte> reprocessingHangarFlag { get; set; }
    }
}
