using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class ramAssemblyLineTypeDetailPerCategory
    {
        public byte assemblyLineTypeID { get; set; }
        public int categoryID { get; set; }
        public Nullable<double> timeMultiplier { get; set; }
        public Nullable<double> materialMultiplier { get; set; }
    }
}
