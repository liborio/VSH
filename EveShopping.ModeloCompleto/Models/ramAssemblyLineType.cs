using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class ramAssemblyLineType
    {
        public byte assemblyLineTypeID { get; set; }
        public string assemblyLineTypeName { get; set; }
        public string description { get; set; }
        public Nullable<double> baseTimeMultiplier { get; set; }
        public Nullable<double> baseMaterialMultiplier { get; set; }
        public Nullable<double> volume { get; set; }
        public Nullable<byte> activityID { get; set; }
        public Nullable<double> minCostPerHour { get; set; }
    }
}
