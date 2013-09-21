using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica.Conversion
{
    public class FittingFormatNotRecognisedException : ApplicationException
    {
        public FittingFormatNotRecognisedException(string msg)
            : base(msg)
        {
        }

        public FittingFormatNotRecognisedException(string msg, Exception inner)
            : base(msg, inner)
        {
        }

    }
}
