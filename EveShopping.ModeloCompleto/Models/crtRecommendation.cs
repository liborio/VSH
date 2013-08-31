using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class crtRecommendation
    {
        public int recommendationID { get; set; }
        public Nullable<int> shipTypeID { get; set; }
        public Nullable<int> certificateID { get; set; }
        public byte recommendationLevel { get; set; }
    }
}
