using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invUniqueName
    {
        public int itemID { get; set; }
        public string itemName { get; set; }
        public Nullable<int> groupID { get; set; }
    }
}
