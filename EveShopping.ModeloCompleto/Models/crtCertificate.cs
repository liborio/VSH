using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class crtCertificate
    {
        public int certificateID { get; set; }
        public Nullable<byte> categoryID { get; set; }
        public Nullable<int> classID { get; set; }
        public Nullable<byte> grade { get; set; }
        public Nullable<int> corpID { get; set; }
        public Nullable<int> iconID { get; set; }
        public string description { get; set; }
    }
}
