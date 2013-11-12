using EveShopping.Modelo.EV;
using EveShopping.Modelo;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVMyLists : EDVBase
    {
        public IEnumerable<EVShoppingListHeader> Lists { get; set; }
        public IEnumerable<EVShoppingListHeader> GroupLists { get; set; }
    }
}