using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class invMetaType
    {
        public int typeID { get; set; }
        public Nullable<int> parentTypeID { get; set; }
        public Nullable<short> metaGroupID { get; set; }
    }
}
