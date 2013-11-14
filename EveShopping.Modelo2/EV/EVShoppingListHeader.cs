using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV
{
    public class EVShoppingListHeader
    {
        public string publicID { get; set; }
        public string name { get; set; }
        public DateTime dateCreation {get; set;}
        public DateTime dateUpdate { get; set; }
        public int staticCount { get; set; }
    }
}
