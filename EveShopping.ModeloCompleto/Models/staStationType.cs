using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class staStationType
    {
        public int stationTypeID { get; set; }
        public Nullable<double> dockEntryX { get; set; }
        public Nullable<double> dockEntryY { get; set; }
        public Nullable<double> dockEntryZ { get; set; }
        public Nullable<double> dockOrientationX { get; set; }
        public Nullable<double> dockOrientationY { get; set; }
        public Nullable<double> dockOrientationZ { get; set; }
        public Nullable<byte> operationID { get; set; }
        public Nullable<byte> officeSlots { get; set; }
        public Nullable<double> reprocessingEfficiency { get; set; }
        public Nullable<bool> conquerable { get; set; }
    }
}
