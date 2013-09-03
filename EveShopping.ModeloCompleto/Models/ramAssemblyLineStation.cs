using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class ramAssemblyLineStation
    {
        public int stationID { get; set; }
        public byte assemblyLineTypeID { get; set; }
        public Nullable<byte> quantity { get; set; }
        public Nullable<int> stationTypeID { get; set; }
        public Nullable<int> ownerID { get; set; }
        public Nullable<int> solarSystemID { get; set; }
        public Nullable<int> regionID { get; set; }
    }
}
