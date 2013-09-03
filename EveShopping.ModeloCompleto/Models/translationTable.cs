using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class translationTable
    {
        public string sourceTable { get; set; }
        public string destinationTable { get; set; }
        public string translatedKey { get; set; }
        public Nullable<int> tcGroupID { get; set; }
        public Nullable<int> tcID { get; set; }
    }
}
