using System;
using System.Collections.Generic;

namespace EveShopping.Modelo.Models
{
    public partial class mapSolarSystem
    {
        public mapSolarSystem()
        {
            this.eshPrices = new List<eshPrice>();
        }

        public Nullable<int> regionID { get; set; }
        public Nullable<int> constellationID { get; set; }
        public int solarSystemID { get; set; }
        public string solarSystemName { get; set; }
        public Nullable<double> x { get; set; }
        public Nullable<double> y { get; set; }
        public Nullable<double> z { get; set; }
        public Nullable<double> xMin { get; set; }
        public Nullable<double> xMax { get; set; }
        public Nullable<double> yMin { get; set; }
        public Nullable<double> yMax { get; set; }
        public Nullable<double> zMin { get; set; }
        public Nullable<double> zMax { get; set; }
        public Nullable<double> luminosity { get; set; }
        public Nullable<bool> border { get; set; }
        public Nullable<bool> fringe { get; set; }
        public Nullable<bool> corridor { get; set; }
        public Nullable<bool> hub { get; set; }
        public Nullable<bool> international { get; set; }
        public Nullable<bool> regional { get; set; }
        public Nullable<bool> constellation { get; set; }
        public Nullable<double> security { get; set; }
        public Nullable<int> factionID { get; set; }
        public Nullable<double> radius { get; set; }
        public Nullable<int> sunTypeID { get; set; }
        public string securityClass { get; set; }
        public virtual ICollection<eshPrice> eshPrices { get; set; }
        public virtual eshTradeHub eshTradeHub { get; set; }
    }
}
