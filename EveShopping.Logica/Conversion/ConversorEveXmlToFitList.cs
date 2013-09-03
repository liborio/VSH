using EveShopping.Modelo;
using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
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
        IEnumerable<FittingAnalyzed> IConversorFit.ToFitList(string fitExterna)
        {
            IList<FittingAnalyzed> listaSalida = new List<FittingAnalyzed>();

            XDocument doc = XDocument.Parse(fitExterna);
            IEnumerable<XElement> fitsXml = doc.Descendants("fitting");

            foreach (var item in fitsXml)
            {
                FittingAnalyzed fit = ObtenerFit(item);
                listaSalida.Add(fit);
            }
            return listaSalida;
        }

        private FittingAnalyzed ObtenerFit(XElement item)
        {
            FittingAnalyzed fit = new FittingAnalyzed();
            fit.Name = item.Attribute("name").Value;

            //obtenemos la descripción
            XElement descXml = item.Descendants("description").FirstOrDefault();
            fit.Description = descXml == null ? null : descXml.Value;

            //obtenemos el tipo de nave
            XElement shipXml = item.Descendants("shipType").FirstOrDefault();
            fit.Ship = shipXml == null ? null : shipXml.Attribute("value").Value;


            IEnumerable<XElement> itemsHardwareXml = item.Descendants("hardware");
            Dictionary<string, FittingHardwareAnalyzed> dicItems =
                new Dictionary<string, FittingHardwareAnalyzed>();

            foreach (var itemHwdXml in itemsHardwareXml)
            {
                FittingHardwareAnalyzed fitHardware = null;
                fitHardware = ExtraerFittingHwdDesdeItemHwdXml(itemHwdXml);
                //Utilizamos el diccionario como caché para apilar las unidades de elementos con el mismo nombre
                if (dicItems.ContainsKey(fitHardware.Name))
                {
                    dicItems[fitHardware.Name].Units += fitHardware.Units;
                }
                else
                {
                    dicItems.Add(fitHardware.Name, fitHardware);
                }
            }

            //Una vez obtenido el diccionario con las unidades apiladas, montamos la lista de salida
            foreach (var itemHwd in dicItems)
            {
                fit.Items.Add(itemHwd.Value);
            }
            return fit;
        }

        private FittingHardwareAnalyzed ExtraerFittingHwdDesdeItemHwdXml(XElement itemHwdXml)
        {
            FittingHardwareAnalyzed fitHardware = new FittingHardwareAnalyzed();
            short qty = 1;
            if (itemHwdXml.Attribute("qty") != null)
            {
                qty = short.Parse(itemHwdXml.Attribute("qty").Value);
            }
            string htype = itemHwdXml.Attribute("type").Value;
            short posEnSlot = 0;
            Enumerados.TipoSlot tipoSlot = Enumerados.TipoSlot.High;
            if (itemHwdXml.Attribute("slot") != null)
            {
                tipoSlot = ObtenerTipoSlotPorNombreEVEXML(itemHwdXml.Attribute("slot").Value, out posEnSlot);
            }
            fitHardware.Units = qty;
            fitHardware.Slot = (short)tipoSlot;
            fitHardware.Name = htype;
            return fitHardware;
        }

        //private void AsignarTipoIdPorNombreItem(IEnumerable<eshFittingHardware> itemsHdw)
        //{
        //    RepositorioItems repo = new RepositorioItems();
        //    Dictionary<string, int> itemsBuscados = new Dictionary<string, int>();
        //    foreach (var item in itemsHdw)
        //    {
        //        if (!itemsBuscados.ContainsKey(item.name))
        //        {
        //            //Buscamos el item en la base de datos si es la primera vez que aparece en esta fit
        //            invType tipo = repo.SelectItemTypePorName(item.name);
        //            if (tipo != null)
        //            {
        //                itemsBuscados.Add(item.name, tipo.typeID);
        //            }
        //            item.typeID = itemsBuscados[item.name];
        //        }
        //    }
        //}



        private Enumerados.TipoSlot ObtenerTipoSlotPorNombreEVEXML(string nombreSlot, out short posicion)
        {
            posicion = 0;
            if (nombreSlot.ToLower().Equals("cargo"))
            {
                return Enumerados.TipoSlot.Cargo;
            }
            if (nombreSlot.ToLower().Equals("drone bay"))
            {
                return Enumerados.TipoSlot.DroneBay;
            }
            string[] nombreSeparado = nombreSlot.Split();
            Enumerados.TipoSlot salida = Enumerados.TipoSlot.High;
            switch (nombreSeparado[0].ToLower())
            {
                case "med":
                    salida = Enumerados.TipoSlot.Medium;
                    break;
                case "low":
                    salida = Enumerados.TipoSlot.Low;
                    break;
                case "rig":
                    salida = Enumerados.TipoSlot.Rigs;
                    break;
                default:
                    salida = Enumerados.TipoSlot.High;
                    break;
            }
            short.TryParse(nombreSeparado.Last(), out posicion);

            return salida;
        }

    }
}
