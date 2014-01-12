using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.JSON
{
    [Serializable]
    public class JAssetDeltas
    {
        public int id { get; set; }
        public int units { get; set; }
    }
}
