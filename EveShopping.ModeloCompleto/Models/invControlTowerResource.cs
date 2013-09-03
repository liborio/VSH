using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invControlTowerResource
    {
        public int controlTowerTypeID { get; set; }
        public int resourceTypeID { get; set; }
        public Nullable<byte> purpose { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<double> minSecurityLevel { get; set; }
        public Nullable<int> factionID { get; set; }
    }
}
