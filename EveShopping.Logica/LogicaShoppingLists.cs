using EveShopping.Logica.Conversion;
using EveShopping.Modelo;
using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica
{
    public class LogicaShoppingLists
    {
        public IEnumerable<eshFitting> ObtenerListaFits(string fitOriginal, TipoFormatoFitOriginal tipo){
            IConversorFit conv = null;
            switch (tipo)
            {
                case TipoFormatoFitOriginal.EFT:
                    throw new NotImplementedException();
                    break;
                case TipoFormatoFitOriginal.EveXml:
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
