using EveShopping.Modelo.EV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web.Modelo
{
    public static class ConvertToJavaScriptArray
    {
        public static string Convert(IEnumerable<EVFittingHardware> data)
        {
            bool first = true;
            StringBuilder builder = new StringBuilder();
            builder.Append('[');
            foreach (var item in data)
            {
                if (!first)
                {
                    builder.Append(',');
                }
                else
                {
                    first = false;
                }
                builder.Append(Convert(item));
            }
            builder.Append(']');
            return builder.ToString();

        }


        public static string Convert(EVFittingHardware data)
        {
            return string.Format("[\"{0}\",\"{1}\",\"{2}\",\"{3}\", \"{4}\"]",                
                data.ImageUrl32,
                data.Name,
                data.Volume,
                data.Units,
                data.FittingHardwareID
                );
        }
    }
}
