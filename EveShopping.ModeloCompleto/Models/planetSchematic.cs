using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class planetSchematic
    {
        public short schematicID { get; set; }
        public string schematicName { get; set; }
        public Nullable<int> cycleTime { get; set; }
    }
}
