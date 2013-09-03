using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class chrAttribute
    {
        public byte attributeID { get; set; }
        public string attributeName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
        public string shortDescription { get; set; }
        public string notes { get; set; }
    }
}
