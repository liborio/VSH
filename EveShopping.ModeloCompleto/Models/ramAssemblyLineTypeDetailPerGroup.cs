using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class ramAssemblyLineTypeDetailPerGroup
    {
        public byte assemblyLineTypeID { get; set; }
        public int groupID { get; set; }
        public Nullable<double> timeMultiplier { get; set; }
        public Nullable<double> materialMultiplier { get; set; }
    }
}
