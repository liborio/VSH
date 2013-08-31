using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class agtAgent
    {
        public int agentID { get; set; }
        public Nullable<byte> divisionID { get; set; }
        public Nullable<int> corporationID { get; set; }
        public Nullable<int> locationID { get; set; }
        public Nullable<byte> level { get; set; }
        public Nullable<short> quality { get; set; }
        public Nullable<int> agentTypeID { get; set; }
        public Nullable<bool> isLocator { get; set; }
    }
}
