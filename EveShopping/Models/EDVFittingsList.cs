using EveShopping.Modelo.EV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVFittingsList
    {
        public bool ShowUnits { get; set; }
        public bool ShowEdit { get; set; }
        public bool ShowPriceAndVolume { get; set; }
        public bool ShowUse { get; set; }

        public string DivID { get; set; }

        public IEnumerable<EVFitting> Fittings { get; set; }

        public EDVFittingsList()
        {
            ShowUnits = true;
            ShowEdit = true;
            ShowPriceAndVolume = true;
            ShowUse = false;
            DivID = "fitsInList";
        }

    }
}