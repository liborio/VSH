using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica.QEntities
{
    internal class QFitting
    {
        public string Description { get; set; }
        public string PublicID { get; set; }
        public int FittingID { get; set; }
        public string Name { get; set; }
        public int ShipID { get; set; }
        public string ShipName { get; set; }
        public double ShipVolume {get; set;}
        public int Units { get; set; }
        public decimal ShipPrice { get; set; }
        public decimal Price { get; set; }
        public double Volume { get; set; }
        public invType InvType { get; set; }
    }
}
