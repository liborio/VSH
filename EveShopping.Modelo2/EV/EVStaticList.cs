using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV
{
    public class EVStaticList
    {
        public bool IsGroup
        {
            get
            {
                return inGroupDate.HasValue;
            }
        }

        public int snapshotID { get; set; }
        public int shoppingListID { get; set; }
        public System.DateTime creationDate { get; set; }
        public double totalVolume { get; set; }
        public decimal totalPrice { get; set; }
        public string publicID { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public string ownerNick { get; set; }
        public DateTime? inGroupDate { get; set; }
    }
}
