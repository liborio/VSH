﻿using EveShopping.Modelo.EV;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVSummary : EDVShopingListBase
    {
        public string ItemArray { get; set; }
        public EVListSummary Summary { get; set; }
    }
}