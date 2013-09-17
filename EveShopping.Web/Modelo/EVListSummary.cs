using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Modelo
{
    public class EVListSummary
    {
        public int ShoppingListID { get; set; }
        public string PublicID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<EVFittingHardware> Items { get; set; }

        public EVListSummary()
        {
            Items = new List<EVFittingHardware>();
        }
    }
}
