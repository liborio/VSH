﻿using EveShopping.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVMyLists
    {
        public IEnumerable<eshShoppingList> Lists { get; set; }
    }
}