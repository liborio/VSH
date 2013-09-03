using EveShopping.Logica;
using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveShopping.Controllers
{
    public class ListsController : Controller
    {
        //
        // GET: /Lists/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ImportFits(string id = null)
        {
            if (id == null)
            {
                id = Guid.NewGuid().ToString();
                return RedirectToAction("ImportFits",new {id = id});
            }

            return View();
        }

        [HttpPost()]
        [ValidateInput(false)]
        public PartialViewResult AnalyzeRawFit(string rawFit)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            IEnumerable<FittingAnalyzed> fits =
                logica.ObtenerListaFits(rawFit, Enumerados.TipoFormatoFitOriginal.EveXml);

            foreach (var fit in fits)
            {
                fit.Items = fit.Items.OrderBy(i => i.Slot).ToList();
            }

            return PartialView("AnalyzedFitList", fits);
        }
    }
}
