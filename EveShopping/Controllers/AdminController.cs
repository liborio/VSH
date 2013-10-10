using EveShopping.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveShopping.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public EmptyResult RefillShipGroups()
        {
            LogicaAdmin logica = new LogicaAdmin();
            logica.FillShipGroupsTable();

            return new EmptyResult();
        }

    }
}
