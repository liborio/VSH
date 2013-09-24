using EveShopping.Logica;
using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.EV;
using EveShopping.Modelo.Models;
using EveShopping.Models;
using EveShopping.Web;
using EveShopping.Web.Agentes;
using EveShopping.Web.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        #region Import Fits

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Create(string slName, string slDescription)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            string id = agente.CrearShoppingList(slName, slDescription);

            return RedirectToAction("ImportFits", new { id = id });

        }

        public ActionResult ImportFits(string id = null)
        {
            if (id == null)
            {
                id = Guid.NewGuid().ToString();
                return RedirectToAction("ImportFits", new { id = id });
            }
            this.ViewBag.PublicID = id;

            EstadoUsuario.CurrentListPublicId = id;

            //cargamos las fits que puedan estar agregadadas a la shopping list
            AgenteShoppingList agente =
                new AgenteShoppingList();
            IEnumerable<EVFitting> fits = agente.SelectFitsEnShoppingList(id);

            EDVImportFits edv = new EDVImportFits();
            edv.Fittings = fits;            

            return View(edv);
        }

        public ActionResult GetList(string id)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            EVListSummary summ = agente.SelectListSummaryPorPublicIDRead(id);

            ViewBag.PublicID = id;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string itemArray = serializer.Serialize(summ.Items);


            EDVSummary edv = new EDVSummary();
            edv.ItemArray = itemArray;
            edv.Summary = summ;

            
            if (summ.PublicID == id)
            {
                return View("Summary", edv);
            }
            else
            {
                return View("Public", edv);
            }


        }

        public ActionResult Summary(string id = null)
        {

            if (id == null)
            {
                id = EstadoUsuario.CurrentListPublicId;
            }
            ViewBag.PublicID = id;
            AgenteShoppingList agente = new AgenteShoppingList();
            EVListSummary summ =  agente.SelectListSummaryPorPublicID(id);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string itemArray = serializer.Serialize(summ.Items);


            EDVSummary edv = new EDVSummary();
            edv.ItemArray = itemArray;
            edv.Summary = summ;

            return View(edv);
        }

        public ActionResult Public(string id)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            EVListSummary summ = agente.SelectListSummaryPorPublicIDRead(id);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string itemArray = serializer.Serialize(summ.Items);

            ViewBag.PublicID = id;
            
            EDVSummary edv = new EDVSummary();
            edv.ItemArray = itemArray;
            edv.Summary = summ;

            return View(edv);
        }


        public JsonResult SummaryData(string id = null)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            EVListSummary summ = agente.SelectListSummaryPorPublicID(id);

            return Json(summ.Items, JsonRequestBehavior.AllowGet);
        }


        [HttpPost()]
        [ValidateInput(false)]
        public PartialViewResult AnalyzeRawFit(string rawFit)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            IEnumerable<FittingAnalyzed> fits =
                logica.ObtenerListaFits(rawFit);

            IDictionary<string, FittingAnalyzed> diccFits =
                new Dictionary<string, FittingAnalyzed>();

            foreach (var fit in fits)
            {
                fit.Items = fit.Items.OrderBy(i => i.Slot).ToList();
                diccFits[fit.Name] = fit;
            }

            Session["lastAnalysedFits"] = diccFits;
            return PartialView("AnalyzedFitList", fits);
        }

        public PartialViewResult UseAnalysedFit(string fitName)
        {
            //Obtenemos la fit del diccionario guardado en sesión, si no está, lanzamos un error
            IDictionary<string, FittingAnalyzed> diccFits = (IDictionary<string, FittingAnalyzed>)Session["lastAnalysedFits"];
            FittingAnalyzed fit = null;
            if ((diccFits != null) && diccFits.ContainsKey(fitName))
            {
                fit = diccFits[fitName];
            }
            if (fit == null) throw new ApplicationException("The fit is not recorded in our archives, try to analyse it again.");

            //Guardamos la fit en base de datos
            LogicaShoppingLists logica = new LogicaShoppingLists();
            int fitID = logica.SaveAnalisedFit(EstadoUsuario.CurrentListPublicId, fit);

            AgenteShoppingList agente = new AgenteShoppingList();
            EVFitting evfit = agente.SelectFitPorID(EstadoUsuario.CurrentListPublicId, fitID);


            return PartialView("PVFitInShoppingList", evfit);

        }

        [HttpPost()]
        public PartialViewResult SetUnitsToFitInShoppingList(int id, short units)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            string publicID = EstadoUsuario.CurrentListPublicId;

            EVFitting evfit = agente.SetUnitsToFitInShoppingList(publicID, id, units);

            return PartialView("PVFitInShoppingList", evfit);
        }

        public ActionResult DeleteFittingFromShoppingList(int id)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            agente.DeleteFitPorID(id);

            return Content(id.ToString());
            //return Json(new { Result = id });
        }


        #endregion


        #region Add Market Items

        public ActionResult AddMarketItems(string id)
        {
            this.ViewBag.PublicID = id;

            EstadoUsuario.CurrentListPublicId = id;
            if (string.IsNullOrEmpty(id))
            {
                throw new ApplicationException(Messages.err_requestWithoutPublicID);
            }
            AgenteMarketItems agente = new AgenteMarketItems();
            AgenteShoppingList agenteShList = new AgenteShoppingList();
            IEnumerable<EVMarketItem> marketItems = agente.SelectMarketGroupsByParentID(null);
            IEnumerable<MarketItem> marketItemsEnShoppingList = agenteShList.SelectMarketItemsEnShoppingList(id);
            EDVAddMarketItems edv = new EDVAddMarketItems();
            edv.MarketItems = marketItems;
            edv.MarketItemsEnShoppingList = marketItemsEnShoppingList;
            return View(edv);
        }

        public PartialViewResult SearchMarketItem(string id)
        {
            AgenteMarketItems agente = new AgenteMarketItems();
            IEnumerable<EVMarketItem> items = agente.SearchMarketItems(id).ToList();
            return PartialView("PVSearchMarketItem", items);
        }

        public PartialViewResult NavigateMarketGroup(int id)
        {
            AgenteMarketItems agente = new AgenteMarketItems();
            IEnumerable<EVMarketItem> marketItems = agente.SelectMarketGroupsByParentID(id);
            IList<invMarketGroup> marketChain = agente.GetParentGroupsChain(id);

            invMarketGroup groupActual = marketChain.Last();
            marketChain.Remove(groupActual);

            EDVAddMarketItems edv = new EDVAddMarketItems();
            edv.MarketItems = marketItems;
            edv.MarketChain = marketChain;
            edv.GroupName = groupActual.marketGroupName;
            return PartialView("PVMarketMenu", edv);
        }

        public PartialViewResult UpdateMarketItemToShoppingList(int id, short units = 1)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            MarketItem item = agente.AddOrUpdateMarketItemEnShoppingList(EstadoUsuario.CurrentListPublicId, id, units);

            return PartialView("PVMarketItemEnShoppingList", item);
        }

        public ActionResult DeleteMarketItemToShoppingList(int id)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            agente.DeleteMarketItemEnShoppingList(EstadoUsuario.CurrentListPublicId, id);

            return null;
        }

        public EmptyResult UpdatePrices()
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            agente.UpdatePrices();
            return new EmptyResult();
        }

        #endregion

            


    }
}
