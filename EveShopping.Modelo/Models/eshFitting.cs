using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshFitting
    {
        public eshFitting()
        {
            this.eshFittingHardwares = new List<eshFittingHardware>();
            this.eshShoppingListFittings = new List<eshShoppingListFitting>();
        }

        public int fittingID { get; set; }
        public string name { get; set; }
        public Nullable<int> shipTypeID { get; set; }
        public string description { get; set; }
        public System.DateTime dateCreation { get; set; }
        public double shipVolume { get; set; }
        public double volume { get; set; }
        public Nullable<int> userID { get; set; }
        public int? urlID { get; set; }
        public string publicID { get; set; }
        public virtual eshTinyUrlMapping eshTinyUrlMapping { get; set; }
        public virtual ICollection<eshFittingHardware> eshFittingHardwares { get; set; }
        public virtual invType invType { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<eshShoppingListFitting> eshShoppingListFittings { get; set; }
    }
}
