using EveShopping.Modelo.Models;
using EveShopping.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveShopping.Logica.Conversion
{
    public class ConversorEveXmlToFitList : IConversorFit
    {
        IEnumerable<eshFitting> IConversorFit.ToFitList(string fitExterna)
        {
            IList<eshFitting> listaSalida = new List<eshFitting>();

            XDocument doc = XDocument.Parse(fitExterna);
            IEnumerable<XElement> fitsXml = doc.Descendants("fitting");

            foreach (var item in fitsXml)
            {
                eshFitting fit = ObtenerFit(item);
                listaSalida.Add(fit);
            }
            return listaSalida;
        }

        private eshFitting ObtenerFit(XElement item)
        {
            eshFitting fit = new eshFitting();
            fit.name = item.Attribute("name").Value;
            
            //obtenemos la descripción
            XElement descXml = item.Descendants("description").FirstOrDefault();
            fit.description = descXml == null ? null : descXml.Value;

            //obtenemos la lista y cantidad de elementos por nombre
            IDictionary<string,short> diccItems = ObtenerDiccionarioItemsHardwareYCantidadesParaFit(item);

            IList<eshFittingHardware> listaHardware = ObtenerListaItemsParaFit(diccItems);
            //agregamos todos los elementos obtenidos a la lista de elementos de nuestro fit.
            foreach (var hwd in listaHardware)
            {
                fit.eshFittingHardwares.Add(hwd);
            }
            return fit;

        }

        private IList<eshFittingHardware> ObtenerListaItemsParaFit(IDictionary<string, short> diccItems)
        {
            RepositorioItems repo = new RepositorioItems();
            IList<eshFittingHardware> listaSalida = new List<eshFittingHardware>();

            foreach (var item in diccItems)
            {
                invType tipo = repo.SelectItemTypePorName(item.Key);
                if (tipo != null)
                {
                    eshFittingHardware hwd = new eshFittingHardware();
                    hwd.typeID = tipo.typeID;
                    hwd.units = item.Value;
                    listaSalida.Add(hwd);
                }
            }

            return listaSalida;
        }

        private static IDictionary<string, short> ObtenerDiccionarioItemsHardwareYCantidadesParaFit(XElement item)
        {
            IDictionary<string, short> items = new Dictionary<string, short>();
            IEnumerable<XElement> itemsXml = item.Descendants("hardware");
            foreach (var itemHwdXml in itemsXml)
            {
                short qty = 1;
                if (itemHwdXml.Attribute("qty") != null)
                {
                    qty = short.Parse(itemHwdXml.Attribute("qty").Value);
                }
                string htype = itemHwdXml.Attribute("type").Value;

                if (items.ContainsKey(htype))
                {
                    items[htype] += qty;
                }
                else
                {
                    items.Add(htype, qty);
                }
            }

            return items;
        }
    }
}
