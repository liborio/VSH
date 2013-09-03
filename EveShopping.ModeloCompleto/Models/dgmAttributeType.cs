using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class dgmAttributeType
    {
        public short attributeID { get; set; }
        public string attributeName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
        public Nullable<double> defaultValue { get; set; }
        public Nullable<bool> published { get; set; }
        public string displayName { get; set; }
        public Nullable<byte> unitID { get; set; }
        public Nullable<bool> stackable { get; set; }
        public Nullable<bool> highIsGood { get; set; }
        public Nullable<byte> categoryID { get; set; }
    }
}
