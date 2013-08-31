using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class mapConstellationJump
    {
        public Nullable<int> fromRegionID { get; set; }
        public int fromConstellationID { get; set; }
        public int toConstellationID { get; set; }
        public Nullable<int> toRegionID { get; set; }
    }
}
