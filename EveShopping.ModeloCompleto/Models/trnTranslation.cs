using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class trnTranslation
    {
        public short tcID { get; set; }
        public int keyID { get; set; }
        public string languageID { get; set; }
        public string text { get; set; }
    }
}
