using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EveShopping.Logica.Conversion
{
    public class ConversorDNAToFitList : IConversorFit
    {

        public IEnumerable<FittingAnalyzed> ToFitList(string fitExterna)
        {
            string nombre = null;

            string cadenaDNA = ObtenerCadenaDNAFromXML(fitExterna, out nombre);
            if (cadenaDNA == null)
            {
                cadenaDNA = ObtenerCadenaDNA(fitExterna, out nombre);
            }

            if (string.IsNullOrEmpty(cadenaDNA))
            {
                throw new FittingFormatNotRecognisedException(Messages.err_notRecognisedFormat);
            }

            DNAIntermediateFit dnaFit = new DNAIntermediateFit();
            dnaFit.Name = nombre;
            int ishipSeparator = cadenaDNA.IndexOf(':');
            
            dnaFit.ShipID = int.Parse(cadenaDNA.Substring(0, ishipSeparator));

            cadenaDNA = cadenaDNA.Substring(ishipSeparator + 1);

            dnaFit.Items = GetModules(cadenaDNA);

            IList<FittingHardwareAnalyzed> fwas = ObtenerFittingHardwareFromDNAModules(dnaFit.Items);
            List<FittingAnalyzed> listaFA = new List<FittingAnalyzed>();

            FittingAnalyzed fa = new FittingAnalyzed();
            fa.Items = fwas;
            fa.Ship = GetShipName(dnaFit.ShipID);
            fa.Name = (!string.IsNullOrEmpty(dnaFit.Name)) ? dnaFit.Name : string.Format("{0}-{1}", fa.Ship, DateTime.Now.ToString());

            listaFA.Add(fa);

            return listaFA;
        }

        private string GetShipName(int id)
        {
            EveShoppingContext contexto = new EveShoppingContext();
            invType ship = contexto.invTypes.Where(i => i.typeID == id).FirstOrDefault();
            if (ship == null)
            {
                throw new FittingFormatNotRecognisedException(Messages.err_notRecognisedItemInFitting);
            }
            return ship.typeName;
        }

        private void AddNamesToDicc(Dictionary<int, FittingHardwareAnalyzed> diccItemDnaSlots, IList<DNAIntermediateFit.DNAItem> dnaItems)
        {
            List<int> typeIDs = new List<int>();
            foreach (var item in dnaItems)
            {
                // we add the itemId to the types that we will have to search in database to get slot and name.
                typeIDs.Add(item.ID);
            }
            EveShoppingContext contexto =
                new EveShoppingContext();
            var query = from it in contexto.invTypes
                        where typeIDs.Contains(it.typeID)
                        select new {
                            id = it.typeID,
                            name = it.typeName
                        };
            foreach (var item in query)
            {
                diccItemDnaSlots[item.id].Name = item.name;
            }
        }

        private IList<FittingHardwareAnalyzed> ObtenerFittingHardwareFromDNAModules(IList<DNAIntermediateFit.DNAItem> dnaItems)
        {
            List<int> typeIDs = new List<int>();
            Dictionary<int, FittingHardwareAnalyzed> diccItemDnaSlots = new Dictionary<int, FittingHardwareAnalyzed>();
            foreach (var item in dnaItems)
            {
                // we add the itemId to the types that we will have to search in database to get slot and name.
                typeIDs.Add(item.ID);
                // we initialize the dictionary of items. Name and real slot will be asigned later
                FittingHardwareAnalyzed fha = new FittingHardwareAnalyzed();
                fha.Units = item.Units;
                fha.Slot = (short)Enumerados.TipoSlot.Cargo;
                diccItemDnaSlots.Add(item.ID, fha);

            }

            EveShoppingContext contexto =
                new EveShoppingContext();

            var query = from it in contexto.invTypes
                        join ig in contexto.invGroups on it.groupID equals ig.groupID
                        join dte in contexto.dmgTypeEffects on it.typeID equals dte.typeID
                        join de in contexto.dmgEffects on dte.effectID equals de.effectID
                        where typeIDs.Contains(it.typeID)                        
                        select new
                        {
                            typeID = it.typeID,
                            dmgEffect = de.effectID
                        };

            //add names to dictionary
            AddNamesToDicc(diccItemDnaSlots, dnaItems);

            //complete de dictionary adding names and slots
            foreach (var item in query)
            {
                MergeDicDnaSlots(diccItemDnaSlots, item.typeID, item.dmgEffect);
            }

            return diccItemDnaSlots.Values.OrderBy(fh => fh.Slot).ToList(); ;
        }

        private void MergeDicDnaSlots(Dictionary<int, FittingHardwareAnalyzed> diccItemDnaSlots, int id, short dnaSlot){
            if (dnaSlot == SlotDDBBInfo.maybeDrone && diccItemDnaSlots[id].Slot == (short)Enumerados.TipoSlot.Cargo)
            {
                diccItemDnaSlots[id].Slot = (short)Enumerados.TipoSlot.DroneBay;

            }
            else
            {
                List<int> slotsFinales = new List<int>() { SlotDDBBInfo.hiPower, SlotDDBBInfo.medPower, SlotDDBBInfo.loPower, SlotDDBBInfo.rigSlot };
                if (slotsFinales.Contains(dnaSlot)) diccItemDnaSlots[id].Slot = (short)SlotDDBBInfo.ConvertToTipoSlot(dnaSlot);
            }
        }

        private IList<DNAIntermediateFit.DNAItem> GetModules(string cadenaDNA)
        {
            string[] rawModules = cadenaDNA.Split(':');
            List<DNAIntermediateFit.DNAItem> modsSalida = new List<DNAIntermediateFit.DNAItem>();
            
            foreach (var szmod in rawModules)
            {
                if (!string.IsNullOrEmpty(szmod))
                {

                    DNAIntermediateFit.DNAItem mod = DNAIntermediateFit.DNAItem.Parse(szmod);
                    modsSalida.Add(mod);
                }
            }
            return modsSalida;
        }

        private string ObtenerCadenaDNAFromXML(string fitExterna, out string nombre)
        {
            try
            {
                XElement elem = XElement.Parse(fitExterna);
                nombre = elem.Value;
                return elem.Attribute("url").Value;
            }
            catch
            {
                nombre = null;
                return null;
            }
        }

        private string ObtenerCadenaDNA(string fitExterna, out string nombre)
        {
            nombre = null;
            if (string.IsNullOrEmpty(fitExterna)) return null;
            int closeCharIndex = fitExterna.IndexOf('>');
            int openCharIndex = fitExterna.IndexOf('<');
            string dnaString = null;


            if (closeCharIndex < openCharIndex)
            {
                fitExterna = fitExterna.Substring(closeCharIndex + 1).Trim();
            }
            //if it doesnt start with url html then we have the row fit
            if (!fitExterna.StartsWith("<url"))
            {
                fitExterna = fitExterna.Trim();
                return fitExterna;
            }
            
            //we have to remove things that are not part of the DNA format or the name
            int initOfDna = fitExterna.IndexOf(':');
            fitExterna = fitExterna.Substring(initOfDna + 1).Trim();
            //we look for the closing char
            closeCharIndex = fitExterna.IndexOf('>');
            dnaString = fitExterna.Substring(0, closeCharIndex).Trim();
            fitExterna = fitExterna.Substring(closeCharIndex + 1).Trim();
            
            //Now we have to find the open char to know the end of the fit name
            openCharIndex = fitExterna.IndexOf('<');
            nombre = fitExterna.Substring(0, openCharIndex).Trim();

            

            return dnaString;
        }
    }
}
