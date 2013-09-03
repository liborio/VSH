using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica.Conversion
{
    /// <summary>
    /// Interfaz que implementarán los conversores de diferentes tipos de configuración de fit
    /// a nuestra lista interna
    /// </summary>
    public interface IConversorFit
    {
        IEnumerable<FittingAnalyzed> ToFitList(string fitExterna);
    }
}
