using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.Models
{
    public class eshTinyUrlMapping
    {
        public eshTinyUrlMapping()
        {
            this.eshFittings = new List<eshFitting>();
            this.eshShoppingLists = new List<eshShoppingList>();
            this.eshSnapshots = new List<eshSnapshot>();
        }

        public int urlId { get; set; }
        public string tinyUrl { get; set; }
        public string finalUrl { get; set; }

        public virtual ICollection<eshSnapshot> eshSnapshots { get; set; }
        public virtual ICollection<eshShoppingList> eshShoppingLists { get; set; }
        public virtual ICollection<eshFitting> eshFittings { get; set; }
    }
}
