using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
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
        public int slotID { get; set; }
        public int shoppingListID { get; set; }
        public virtual ICollection<eshFittingHardware> eshFittingHardwares { get; set; }
        public virtual eshFittingSlot eshFittingSlot { get; set; }
        public virtual eshShoppingList eshShoppingList { get; set; }
        public virtual invType invType { get; set; }
    }
}
