using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVAnalysedFitList
    {
        public IEnumerable<FittingAnalyzed> Fittings { get; set; }
        public string UseText { get; set; }
        public string ControllerName {get; set;}

    }
}