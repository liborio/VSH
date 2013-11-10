using EveShopping.Web.Agentes;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveShopping.Controllers
{
    public class HomeController : VSHBaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            SetHeadCounters();


            return View();
        }

        public ActionResult Videos()
        {
            SetHeadCounters();
            return View();
        }

        public ActionResult About()
        {
            base.SetHeadCounters();
            SetHeadCounters();
            return View();
        }

        public ActionResult Changes(string id)
        {
            id = id.ToLower();
            id = id.Trim(new char[] { 'v' });
            return RedirectToAction("v", "Changes", new { id = id });
        }

        public ActionResult FAQ()
        {
            base.SetHeadCounters();
            return View();
        }

        public ActionResult Scenarios()
        {
            base.SetHeadCounters();
            return View();
        }

    }
}
