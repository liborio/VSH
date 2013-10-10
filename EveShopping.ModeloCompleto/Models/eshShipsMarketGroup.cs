using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshShipsMarketGroup
    {
        public int typeID { get; set; }
        public int marketGroupID { get; set; }
        public Nullable<bool> mock { get; set; }
        public virtual invMarketGroup invMarketGroup { get; set; }
        public virtual invType invType { get; set; }
    }
}
