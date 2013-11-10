using EveShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveShopping.Controllers
{
    public class ChangesController : VSHBaseController
    {
        //
        // GET: /Changes/

        public ActionResult v(string id = "1-0-0-4")
        {
            base.SetHeadCounters();
            id = id.ToLower().Replace('-', '.');
            EDVChangeLog edv = new EDVChangeLog();
            edv.Version = id;
            return View(edv);
        }

    }
}
