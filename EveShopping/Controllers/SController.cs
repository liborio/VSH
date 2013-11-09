using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveShopping.Controllers
{
    public class SController : Controller
    {
        //
        // GET: /S/

        public ActionResult Fit(string id)
        {
            return RedirectToAction("Fitting", "Fittings", new { id = id });
        }

        public ActionResult Nsl(string id)
        {
            return RedirectToAction("Summary", "Lists", new { id = id });
        }

        public ActionResult Ssl(string id)
        {
            return RedirectToAction("Static", "Lists", new { id = id });
        }
        public ActionResult Gsl(string id)
        {
            return RedirectToAction("Summary", "Group", new { id = id });
        }
    }
}
