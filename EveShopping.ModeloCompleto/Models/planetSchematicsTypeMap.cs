using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class planetSchematicsTypeMap
    {
        public short schematicID { get; set; }
        public int typeID { get; set; }
        public Nullable<short> quantity { get; set; }
        public Nullable<bool> isInput { get; set; }
    }
}
