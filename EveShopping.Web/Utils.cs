using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web
{
    public class Utils
    {
        public static string GetVersion()
        {
            Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
        }

        public static bool Min1140
        {
            get
            {
                return ScreenSize >= 1140;
            }
        }

        private static int ScreenSize
        {
            get
            {
                return int.Parse( System.Web.HttpContext.Current.Request.Params["lalala"]);
            }
        }
    }
}
