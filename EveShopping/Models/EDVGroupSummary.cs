﻿using EveShopping.Modelo.EV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVGroupSummary : EDVGroupListBase
    {
        public EVListSummary Summary { get; set; }
        public IEnumerable<EVStaticList> Lists { get; set; }

    }
}