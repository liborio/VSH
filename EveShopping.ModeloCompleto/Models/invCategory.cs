using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class invCategory
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
        public Nullable<bool> published { get; set; }
    }
}
