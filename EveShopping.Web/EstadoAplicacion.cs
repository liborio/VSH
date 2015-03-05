using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EveShopping.Web
{
    public class EstadoAplicacion
    {
        public static DateTime LastPricesUpdateTime{
            get
            {
                if (HttpContext.Current.Cache["__LastPricesUpdateTime__"] == null){
                    return DateTime.MinValue;
                }

                return (DateTime) HttpContext.Current.Cache["__LastPricesUpdateTime__"];
            }
            set 
            {
                HttpContext.Current.Cache["__LastPricesUpdateTime__"] = value;
            }
        }
    }
}
