using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica.Conversion
{
    public class ConversorEFTToFitList : IConversorFit
    {

        private Enumerados.TipoSlot SlotActual {get;set;}

        public IEnumerable<FittingAnalyzed> ToFitList(string fitExterna)
        {
            IList<FittingAnalyzed> listaSalida = new List<FittingAnalyzed>();

            SlotActual = Enumerados.TipoSlot.Ship;
            string[] lines = fitExterna.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                        
            FittingAnalyzed fit = null;
            List<string> lineasSlot = new List<string>();
            bool changingSlot = false;
            foreach (var item in lines)
            {
                if (SlotActual == Enumerados.TipoSlot.Ship)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        fit = ObtenerFit(item);
                        listaSalida.Add(fit);
                        SlotActual = this.GetNextSlot(SlotActual);
                        changingSlot = true;
                    }
                    continue;
                }
                if (string.IsNullOrEmpty(item))
                {
                    if (!changingSlot)
                    {
                        IEnumerable<FittingHardwareAnalyzed> slot = ObtenerFittingHardwareSlot(lineasSlot, SlotActual);
                        foreach (var fha in slot)
                        {
                            fit.Items.Add(fha);
                        }
                        SlotActual = this.GetNextSlot(SlotActual);
                        lineasSlot.Clear();
                    }
                    else
                    {
                        changingSlot = true;
                    }
                }
                else
                {
                    changingSlot = false;
                    lineasSlot.Add(item);      
              
                }
            }
            if (lineasSlot != null && lineasSlot.Count > 0)
            {
                IEnumerable<FittingHardwareAnalyzed> slot = ObtenerFittingHardwareSlot(lineasSlot, SlotActual);
                foreach (var fha in slot)
                {
                    fit.Items.Add(fha);
                }
            }
            return listaSalida;           

        }


        private FittingAnalyzed ObtenerFit(string fitExterna)
        {
            try
            {
                fitExterna = fitExterna.TrimStart('[');
                fitExterna = fitExterna.TrimEnd(']');
                string[] nombres = fitExterna.Split(',');

                string nombreNave = nombres[0].Trim();
                string nombreFit = nombres[1].Trim();

                FittingAnalyzed fitting = new FittingAnalyzed();
                fitting.Name = nombreFit;
                fitting.Ship = nombreNave;

                return fitting;
            }
            catch (Exception ex)
            {
                throw new FittingFormatNotRecognisedException(Messages.err_notRecognisedFormat, ex);
            }
        }


        private IEnumerable<FittingHardwareAnalyzed> ObtenerFittingHardwareSlot(IEnumerable<string> lines, Enumerados.TipoSlot slot)
        {
            IDictionary<string, FittingHardwareAnalyzed> fwdicc = new Dictionary<string,FittingHardwareAnalyzed>();
            string hwdname = null;
            foreach (var item in lines)
            {
                int initialUnits = 1;
                FittingHardwareAnalyzed fha = null;
                hwdname = item.Trim();
                //Si es un Empty slot lo quitamos
                if (hwdname.ToLower().StartsWith("[empty")) break;
                //quitamos la coma para eliminar las ammo de los items que las admiten
                if (hwdname.Contains(',')){
                    hwdname = hwdname.Split(',').First();
                }
                //si estamos en el slot de drones o bay, puede aparecer un multiplicador, lo quitamos y tomamos las unidades
                if (slot == Enumerados.TipoSlot.DroneBay || slot == Enumerados.TipoSlot.Cargo)
                {
                    int posX = hwdname.LastIndexOf(" x");
                    if (posX >= 0)
                    {
                        string szunits = hwdname.Substring(posX + 2, hwdname.Length - posX - 2);
                        if (int.TryParse(szunits, out initialUnits))
                        {
                            hwdname = hwdname.Substring(0, posX);
                        }
                    }

                }
                if (!fwdicc.ContainsKey(hwdname))
                {
                    fha = new FittingHardwareAnalyzed();
                    fha.Name = hwdname;
                    fha.Slot = (short)slot;
                    fha.Units = (initialUnits - 1);
                    fwdicc.Add(hwdname, fha);
                }
                else
                {
                    fha = fwdicc[hwdname];
                }
                fha.Units++;
            }
            return fwdicc.Values;                        
        }

        private Enumerados.TipoSlot GetNextSlot(Enumerados.TipoSlot slotActual)
        {
            switch (slotActual)
            {
                case Enumerados.TipoSlot.Ship:
                    return Enumerados.TipoSlot.Low;
                case Enumerados.TipoSlot.High:
                    return Enumerados.TipoSlot.Rigs;
                case Enumerados.TipoSlot.Medium:
                    return Enumerados.TipoSlot.High;
                case Enumerados.TipoSlot.Low:
                    return Enumerados.TipoSlot.Medium;
                case Enumerados.TipoSlot.Rigs:
                    return Enumerados.TipoSlot.DroneBay;
                case Enumerados.TipoSlot.DroneBay:
                case Enumerados.TipoSlot.Cargo:
                default:
                    return Enumerados.TipoSlot.Cargo;
            }
        }
    }
}
