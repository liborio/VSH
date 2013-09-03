using EveShopping.Logica.Conversion;
using EveShopping.Modelo;
using EveShopping.Modelo.Models;
using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica
{
    public class LogicaShoppingLists
    {
        public IEnumerable<FittingAnalyzed> ObtenerListaFits(string fitOriginal, Enumerados.TipoFormatoFitOriginal tipo){
            IConversorFit conv = null;
            switch (tipo)
            {
                case Enumerados.TipoFormatoFitOriginal.EFT:
                    throw new NotImplementedException();
                    break;
                case Enumerados.TipoFormatoFitOriginal.EveXml:
                default:
                    conv = new ConversorEveXmlToFitList();
                    break;
            }
            return conv.ToFitList(fitOriginal);
        }

        public string CrearShoppingList(eshShoppingList lista)
        {
            string publicID = Guid.NewGuid().ToString();
            lista.publicID = publicID;
            EveShoppingContext contexto = new EveShoppingContext();
            contexto.eshShoppingLists.Add(lista);
            contexto.SaveChanges();
            return publicID;
        }
    }
}
