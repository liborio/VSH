using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invContrabandType
    {
        public int factionID { get; set; }
        public int typeID { get; set; }
        public Nullable<double> standingLoss { get; set; }
        public Nullable<double> confiscateMinSec { get; set; }
        public Nullable<double> fineByValue { get; set; }
        public Nullable<double> attackMinSec { get; set; }
    }
}
