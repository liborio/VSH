using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class mapSolarSystemJump
    {
        public Nullable<int> fromRegionID { get; set; }
        public Nullable<int> fromConstellationID { get; set; }
        public int fromSolarSystemID { get; set; }
        public int toSolarSystemID { get; set; }
        public Nullable<int> toConstellationID { get; set; }
        public Nullable<int> toRegionID { get; set; }
    }
}
