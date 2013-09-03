using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class trnTranslationColumn
    {
        public Nullable<short> tcGroupID { get; set; }
        public short tcID { get; set; }
        public string tableName { get; set; }
        public string columnName { get; set; }
        public string masterID { get; set; }
    }
}
