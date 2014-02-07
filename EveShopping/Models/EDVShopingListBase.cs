using EveShopping.Modelo;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVShopingListBase: EDVBase
    {
        public string ShoppingListName { get; set; }
        public bool IsShoppingListFree { get; set; }
        public bool allowEdit { get; set; }
        public EDPVListNavMenu<Enumerados.StepsForPVPList> ListNavMenu { get; set; }
    }
}