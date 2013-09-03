using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invGroup
    {
        public int groupID { get; set; }
        public Nullable<int> categoryID { get; set; }
        public string groupName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
        public Nullable<bool> useBasePrice { get; set; }
        public Nullable<bool> allowManufacture { get; set; }
        public Nullable<bool> allowRecycler { get; set; }
        public Nullable<bool> anchored { get; set; }
        public Nullable<bool> anchorable { get; set; }
        public Nullable<bool> fittableNonSingleton { get; set; }
        public Nullable<bool> published { get; set; }
    }
}
