using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class ramAssemblyLine
    {
        public int assemblyLineID { get; set; }
        public Nullable<byte> assemblyLineTypeID { get; set; }
        public Nullable<int> containerID { get; set; }
        public Nullable<System.DateTime> nextFreeTime { get; set; }
        public Nullable<byte> UIGroupingID { get; set; }
        public Nullable<double> costInstall { get; set; }
        public Nullable<double> costPerHour { get; set; }
        public Nullable<byte> restrictionMask { get; set; }
        public Nullable<double> discountPerGoodStandingPoint { get; set; }
        public Nullable<double> surchargePerBadStandingPoint { get; set; }
        public Nullable<double> minimumStanding { get; set; }
        public Nullable<double> minimumCharSecurity { get; set; }
        public Nullable<double> minimumCorpSecurity { get; set; }
        public Nullable<double> maximumCharSecurity { get; set; }
        public Nullable<double> maximumCorpSecurity { get; set; }
        public Nullable<int> ownerID { get; set; }
        public Nullable<byte> activityID { get; set; }
    }
}
