using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class chrRace
    {
        public byte raceID { get; set; }
        public string raceName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
        public string shortDescription { get; set; }
    }
}
