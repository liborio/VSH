using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EV{
    public class EVFitting : BaseItem
    {
        //public int ItemID {get; set;} //FittingID
        //public string Name { get; set; }
        public string Description { get; set; }
        public string ShipName { get; set; }
        public double ShipVolume { get; set; }
        //public short Units { get; set; }
        //public double Volume { get; set; }
        public IList<EVFittingHardware> FittingHardwares { get; set; }
        public int ShipID { get; set; }
        //public string ImageUrl32 { get; set; } //ShipImageUrl32
        public decimal ShipPrice { get; set; }
        //public decimal TotalPrice { get; set; } //Price
        public EVFitting()
        {
            FittingHardwares = new List<EVFittingHardware>();
        }
    }
}
