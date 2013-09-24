using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica
{
    public interface IImageResolver
    {
        string GetImageURL(int id);
    }
}
