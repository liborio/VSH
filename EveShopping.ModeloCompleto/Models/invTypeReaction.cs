using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invTypeReaction
    {
        public int reactionTypeID { get; set; }
        public bool input { get; set; }
        public int typeID { get; set; }
        public Nullable<short> quantity { get; set; }
    }
}
