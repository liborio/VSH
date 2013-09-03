using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invFlag
    {
        public short flagID { get; set; }
        public string flagName { get; set; }
        public string flagText { get; set; }
        public Nullable<int> orderID { get; set; }
    }
}
