using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EveShopping.Web
{
    public class EstadoUsuario
    {
        private static HttpContext Contexto
        {
            get
            {
                return System.Web.HttpContext.Current;
            }
        }

        public static string CurrentListPublicId{
            get
            {
                string[] segments = Contexto.Request.UrlReferrer.Segments;
                string szguid = segments[segments.Count() - 1];
                return szguid;
            }
            set
            {
            }
        }
    }
}
