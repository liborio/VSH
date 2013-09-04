using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Modelo
{
   public class EVMarketItem
    {
       public int ItemID { get; set; }
       public int? ParentID { get; set; }
       public string Name { get; set; }
       public string UrlIcon { get; set; }
       public bool EsFinal { get; set; }
    }
}
