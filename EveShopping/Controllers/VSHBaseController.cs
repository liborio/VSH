using EveShopping.Web.Agentes;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveShopping.Controllers
{
    public class VSHBaseController : Controller
    {
        public void SetHeadCounters()
        {
            if (Request.IsAuthenticated)
            {
                int fittingCount;
                int listCount;
                AgenteShared agente = new AgenteShared();
                agente.SetMenuCounters(User.Identity.Name, out fittingCount, out listCount);
                ViewBag.FittingCount = fittingCount;
                ViewBag.ListCount = listCount;
            }
        }
    }
}