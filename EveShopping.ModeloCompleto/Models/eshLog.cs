using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshLog
    {
        public int LogID { get; set; }
        public int Code { get; set; }
        public short Severity { get; set; }
        public string Message { get; set; }
    }
}
