using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveShopping.Modelo;

namespace EveShopping.Logica.Conversion
{
    public class SlotDDBBInfo
    {
        public static int[] SlotIds = new int[] { 10, 11, 12, 13, 2663 };
        public const int loPower = 11;
        public const int hiPower = 12;
        public const int medPower = 13;
        public const int rigSlot = 2663;
        public const int maybeDrone = 10;
        public const int cargo = 10000;

        public static Enumerados.TipoSlot ConvertToTipoSlot(int slot)
        {
            switch (slot)
            {
                case loPower:
                    return Enumerados.TipoSlot.Low;
                case hiPower:
                    return Enumerados.TipoSlot.High;
                case medPower:
                    return Enumerados.TipoSlot.Medium;
                case rigSlot:
                    return Enumerados.TipoSlot.Rigs;
                case maybeDrone:
                    return Enumerados.TipoSlot.DroneBay;
                default:
                    return Enumerados.TipoSlot.Cargo;
            }
        }
    }
}
