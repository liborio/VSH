using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class invType
    {
        public invType()
        {
            this.eshFittingHardwares = new List<eshFittingHardware>();
            this.eshFittings = new List<eshFitting>();
            this.eshShoppingListInvTypes = new List<eshShoppingListInvType>();
        }

        public int typeID { get; set; }
        public Nullable<int> groupID { get; set; }
        public string typeName { get; set; }
        public string description { get; set; }
        public Nullable<double> mass { get; set; }
        public Nullable<double> volume { get; set; }
        public Nullable<double> capacity { get; set; }
        public Nullable<int> portionSize { get; set; }
        public Nullable<byte> raceID { get; set; }
        public Nullable<decimal> basePrice { get; set; }
        public Nullable<bool> published { get; set; }
        public Nullable<int> marketGroupID { get; set; }
        public Nullable<double> chanceOfDuplicating { get; set; }
        public virtual ICollection<eshFittingHardware> eshFittingHardwares { get; set; }
        public virtual ICollection<eshFitting> eshFittings { get; set; }
        public virtual ICollection<eshShoppingListInvType> eshShoppingListInvTypes { get; set; }
    }
}
