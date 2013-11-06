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

        private static string GetUrlGUID(Uri _uri)
        {
            if (_uri == null) return null;

            string[] segments = _uri.Segments;
            string szguid = segments[segments.Count() - 1];
            Guid test;
            if (Guid.TryParse(szguid, out test))
            {
                return szguid;
            }
            return null;
        }

        public static bool IsIGB()
        {
            return HttpContext.Current.Request.UserAgent.EndsWith("EVE-IGB");
        }

        public static string CurrentListPublicId{
            get
            {
                string strguid = GetUrlGUID(Contexto.Request.Url);
                if (strguid == null)
                {
                    strguid = GetUrlGUID(Contexto.Request.UrlReferrer);
                }
                return strguid;
            }
            set
            {
            }
        }
    }
}
