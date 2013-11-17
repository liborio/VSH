using EveShopping.Logica;
using EveShopping.Modelo;
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

        private static IImageResolver Image32Resolver { get; set; }
        private static IImageResolver Image256Resolver { get; set; }

        static VSHMappings()
        {
            Image32Resolver = new Imagex32UrlResolver();
        }

        public static string ResolveImage32(int id)
        {
            return Image32Resolver.GetImageURL(id);
        }

        public static string ResolveImageChar256(long id)
        {
            return string.Format("https://image.eveonline.com/Character/{0}_200.jpg", id);
        }

        public static string ResolverImageCorp30(long id)
        {
            return string.Format("https://image.eveonline.com/Corporation/{0}_30.png", id);
        }

        public static string ResolverImageAlli30(long id)
        {
            return string.Format("https://image.eveonline.com/Alliance/{0}_30.png", id);
        }
        
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
                return string.Format("{0:F} M", GetNormalizedNumber(precio / 1000000));
            }

            if (precio > 1000)
            {
                return string.Format("{0:F} K", GetNormalizedNumber(precio / 1000));
            }
                        
            return string.Format("{0:F}", GetNormalizedNumber( precio));
        }
        
        public static string GetNormalizedNumber(int number)
        {
            string specifier = "#,#";
            return AddZeroIfNeeded(number.ToString(specifier));
        }

        public static string GetNormalizedNumber(decimal number)
        {
            string specifier = "#,#.##";            
            return AddZeroIfNeeded( number.ToString(specifier));
        }

        public static string GetNormalizedNumber(double number)
        {
            string specifier = "#,#.##";
            return AddZeroIfNeeded( number.ToString(specifier));
        }

        private static string AddZeroIfNeeded(string number)
        {
            if (string.IsNullOrEmpty(number)) return "0";
            if (number.StartsWith(".")) return "0" + number;
            return number;

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
