using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class ramActivity
    {
        public byte activityID { get; set; }
        public string activityName { get; set; }
        public string iconNo { get; set; }
        public string description { get; set; }
        public Nullable<bool> published { get; set; }
    }
}
