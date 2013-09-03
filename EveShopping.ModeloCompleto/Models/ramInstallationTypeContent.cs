using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class ramInstallationTypeContent
    {
        public int installationTypeID { get; set; }
        public byte assemblyLineTypeID { get; set; }
        public Nullable<byte> quantity { get; set; }
    }
}
