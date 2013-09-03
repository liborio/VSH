using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class ramTypeRequirement
    {
        public int typeID { get; set; }
        public byte activityID { get; set; }
        public int requiredTypeID { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<double> damagePerJob { get; set; }
        public Nullable<bool> recycle { get; set; }
    }
}
