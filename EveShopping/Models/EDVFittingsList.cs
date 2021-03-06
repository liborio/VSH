﻿using EveShopping.Modelo.EV;
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
        public bool ShowDelete { get; set; }
        public bool ShowExport { get; set; }

        public string DivID { get; set; }
        public string PublicID { get; set; }

        public IEnumerable<EVFitting> Fittings { get; set; }

        public EDVFittingsList()
        {
            ShowUnits = true;
            ShowEdit = true;
            ShowExport = true;
            ShowPriceAndVolume = true;
            ShowUse = false;
            ShowDelete = true;
            DivID = "fitsInList";
        }

    }
}