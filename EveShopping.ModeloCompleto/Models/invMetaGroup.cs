using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invMetaGroup
    {
        public short metaGroupID { get; set; }
        public string metaGroupName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
    }
}
