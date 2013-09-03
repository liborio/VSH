using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eveUnit
    {
        public byte unitID { get; set; }
        public string unitName { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
    }
}
