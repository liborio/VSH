using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class dgmTypeEffect
    {
        public int typeID { get; set; }
        public short effectID { get; set; }
        public Nullable<bool> isDefault { get; set; }
    }
}
