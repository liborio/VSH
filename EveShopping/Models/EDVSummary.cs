using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDVSummary
    {
        public string ItemArray { get; set; }
        public EVListSummary Summary { get; set; }
    }
}