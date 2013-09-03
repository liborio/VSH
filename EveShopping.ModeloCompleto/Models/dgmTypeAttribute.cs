using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class dgmTypeAttribute
    {
        public int typeID { get; set; }
        public short attributeID { get; set; }
        public Nullable<int> valueInt { get; set; }
        public Nullable<double> valueFloat { get; set; }
    }
}
