using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class eshFitting
    {
        public eshFitting()
        {
            this.eshFittingHardwares = new List<eshFittingHardware>();
        }

        public int fittingID { get; set; }
        public string name { get; set; }
        public Nullable<int> shipTypeID { get; set; }
        public string description { get; set; }
        public int shoppingListID { get; set; }
        public virtual ICollection<eshFittingHardware> eshFittingHardwares { get; set; }
        public virtual invType invType { get; set; }
        public virtual eshShoppingList eshShoppingList { get; set; }
    }
}
