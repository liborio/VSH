﻿using EveShopping.Modelo;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Web
{
    public class VSHMappings
    {

        public static ulong GetLongFromDate(DateTime date)
        {
            ulong res = 0;
            res += (ulong)date.Second;
            res += (ulong)date.Minute * 100;
            res += (ulong)date.Hour * 10000;
            res += (ulong)date.Day * 1000000;
            res += (ulong)date.Month * 100000000;
            res += (ulong)date.Year * 10000000000;
            return res;
        }

        public static string GetGridDateFormat(DateTime date)
        {
            return string.Format("{0:dd MMM yyy, HH:mm}", date);
        }

        public static string GetNormalizedPrice(decimal precio)
        {
            if (precio > 1000000)
            {
                return string.Format("{0:F} M", precio / 1000000);
            }

            if (precio > 1000)
            {
                return string.Format("{0:F} K", precio / 1000);
            }

            return string.Format("{0:F}", precio);
        }

        public static string GetSlotName(int slot)
        {
            return GetSlotName((Enumerados.TipoSlot)slot);
        }

            public static string GetSlotName(Enumerados.TipoSlot slot)
        {
            switch (slot)
            {
                case Enumerados.TipoSlot.High:
                    return "Fitted - High slot";
                case Enumerados.TipoSlot.Medium:
                    return "Fitted - Mid slot";
                case Enumerados.TipoSlot.Low:
                    return "Fitted - Low slot";
                case Enumerados.TipoSlot.Rigs:
                    return "Fitted - Rig slot";
                case Enumerados.TipoSlot.DroneBay:
                    return "Drone bay";
                case Enumerados.TipoSlot.Cargo:
                default:
                    return "Cargo bay";
            }
        }

        public static string GetImageName(int slot)
        {
            return GetImageName((Enumerados.TipoSlot)slot);
        }


        public static string GetImageName(Enumerados.TipoSlot slot)
        {
            switch (slot)
            {
                case Enumerados.TipoSlot.High:
                    return "iconHighSlot32.png";
                case Enumerados.TipoSlot.Medium:
                    return "iconMidSlot32.png";
                case Enumerados.TipoSlot.Low:
                    return "iconLowSlot32.png";
                case Enumerados.TipoSlot.Rigs:
                    return "iconRigSlot32.png";
                case Enumerados.TipoSlot.DroneBay:
                    return "iconDroneBay32.png";
                case Enumerados.TipoSlot.Cargo:
                default:
                    return "iconCargoBay32.png";
            }
        }
    }
}
