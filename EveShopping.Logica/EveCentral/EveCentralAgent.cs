using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveShopping.Logica.EveCentral
{
    public class EveCentralAgent
    {
        public const string FORMAT_TYPEID = "&typeid={0}";
        public const string FORMAT_USESYSTEM = "&usesystem={0}";


        public const string Url = "http://api.eve-central.com/api/marketstat?sethours=24";

/// <summary>
/// Obtiene las estadisticas de precios en un hub para los items proporcionados.
/// </summary>
/// <param name="itemsID"></param>
/// <param name="hub"></param>
/// <returns></returns>
        public IDictionary<int,ItemPriceStats> GetPricesForHub(IEnumerable<int> itemsID, int hub)
        {
            //preparamos la query
            StringBuilder szbuilder = new StringBuilder(Url);
            foreach (var item in itemsID)
            {
                szbuilder.AppendFormat(FORMAT_TYPEID, item);
            }
            szbuilder.AppendFormat(FORMAT_USESYSTEM, hub);

            System.Net.WebRequest request =
    System.Net.HttpWebRequest.Create(szbuilder.ToString());

            Dictionary<int, ItemPriceStats> salida = new Dictionary<int, ItemPriceStats>();

            WebResponse respuesta = request.GetResponse();
            using (Stream canalRespuesta = respuesta.GetResponseStream())
            {
                XDocument doc = XDocument.Load(canalRespuesta);
                IEnumerable<XElement> itemTypes = doc.Descendants("type");
                foreach (XElement type in itemTypes)
                {
                    int typeId = int.Parse( type.Attribute("id").Value);
                    XElement buy = type.Element("buy");
                    ItemPriceStats stats = new ItemPriceStats();
                    stats.Avg = decimal.Parse(buy.Element("avg").Value);
                    stats.Max = decimal.Parse(buy.Element("max").Value);
                    stats.Min = decimal.Parse(buy.Element("min").Value);
                    stats.Median = decimal.Parse(buy.Element("median").Value);
                    salida.Add(typeId, stats);
                }
            }
            return salida;

        }


        public IEnumerable<ItemPrice> GetPrices(IEnumerable<int> itemId, IEnumerable<int> hubs)
        {
            IList<ItemPrice> salida = new List<ItemPrice>();
            foreach (var hub in hubs)
            {
                IDictionary<int, ItemPriceStats> stats = this.GetPricesForHub(itemId, hub);
                foreach (var item in stats)
                {
                    ItemPrice ip = new ItemPrice();
                    ip.ItemID = item.Key;
                    ip.Stats = item.Value;
                    ip.HubID = hub;
                    salida.Add(ip);
                }
            }
            return salida;

            
        }
    }
}
