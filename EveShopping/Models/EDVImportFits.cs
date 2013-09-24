using EveShopping.Modelo.EV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVImportFits : EDVShopingListBase
    {
        public IEnumerable<EVFitting> Fittings { get; set; }
    }
}