using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshSnapshotInvType
    {
        public int snapshotID { get; set; }
        public int typeID { get; set; }
        public short units { get; set; }
        public decimal unitPrice { get; set; }
        public Nullable<double> volume { get; set; }
        public virtual eshSnapshot eshSnapshot { get; set; }
        public virtual invType invType { get; set; }
    }
}
