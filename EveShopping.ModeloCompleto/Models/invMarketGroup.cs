using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class invMarketGroup
    {
        public int marketGroupID { get; set; }
        public Nullable<int> parentGroupID { get; set; }
        public string marketGroupName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
        public Nullable<bool> hasTypes { get; set; }
    }
}
