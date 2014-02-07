using EveShopping.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVGroupListBase
    {
        public EDPVListNavMenu<Enumerados.StepsForGroupList> ListNavMenu { get; set; }
        public bool allowEdit { get; set; }

    }
}