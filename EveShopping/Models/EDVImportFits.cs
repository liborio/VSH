using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVImportFits : EDVShopingListBase
    {
        public IEnumerable<EveShopping.Web.Modelo.EVFitting> Fittings { get; set; }
    }
}