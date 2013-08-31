using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class crpNPCCorporationDivision
    {
        public int corporationID { get; set; }
        public byte divisionID { get; set; }
        public Nullable<byte> size { get; set; }
    }
}
