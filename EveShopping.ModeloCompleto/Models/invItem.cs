using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class invItem
    {
        public long itemID { get; set; }
        public int typeID { get; set; }
        public int ownerID { get; set; }
        public long locationID { get; set; }
        public short flagID { get; set; }
        public int quantity { get; set; }
    }
}
