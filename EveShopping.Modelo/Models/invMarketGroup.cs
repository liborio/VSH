using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invMarketGroup
    {
        public invMarketGroup()
        {
            this.eshShipsMarketGroups = new List<eshShipsMarketGroup>();
        }

        public int marketGroupID { get; set; }
        public Nullable<int> parentGroupID { get; set; }
        public string marketGroupName { get; set; }
        public string description { get; set; }
        public Nullable<int> iconID { get; set; }
        public Nullable<bool> hasTypes { get; set; }
        public virtual ICollection<eshShipsMarketGroup> eshShipsMarketGroups { get; set; }
    }
}
