using EveShopping.Modelo.Models;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVMyLists : EDVBase
    {
        public IEnumerable<eshShoppingList> Lists { get; set; }
    }
}