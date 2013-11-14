using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EntidadesAux
{
    public class FittingAnalyzed
    {
        public FittingAnalyzed()
        {
            Items = new List<FittingHardwareAnalyzed>();
        }

        public string Name { get; set; }
        public string Ship { get; set; }
        public string Description { get; set; }
        public IList<FittingHardwareAnalyzed> Items { get; set; }
    }
}
