using EveShopping.Modelo.EV;
using EveShopping.Modelo.Models;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVMyFittings : EDVBase
    {
        public IEnumerable<ShipMarketGroup> MarketItems { get; set; }
        public IEnumerable<invMarketGroup> MarketChain { get; set; }
        public EDVFittingsList Fittings { get; set; }

        public string GroupName { get; set; }

        public int ContextSelectedFitID { get; set; }
        public string ContextSelectedFitName { get; set; }
    }
}