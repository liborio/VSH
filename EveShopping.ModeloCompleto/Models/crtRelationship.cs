using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class crtRelationship
    {
        public int relationshipID { get; set; }
        public Nullable<int> parentID { get; set; }
        public Nullable<int> parentTypeID { get; set; }
        public Nullable<byte> parentLevel { get; set; }
        public Nullable<int> childID { get; set; }
    }
}
