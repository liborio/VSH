using EveShopping.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web
{
    public class Imagex32UrlResolver : IImageResolver
    {
        public string GetImageURL(int id)
        {
            return string.Format("http://image.eveonline.com/Type/{0}_32.png", id);
        }
    }
}
