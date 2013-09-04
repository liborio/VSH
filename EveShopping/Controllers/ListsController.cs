using EveShopping.Logica;
using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
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
             EstadoUsuario.CurrentListPublicId = id;

            //cargamos las fits que puedan estar agregadadas a la shopping list
             AgenteShoppingList agente =
                 new AgenteShoppingList();
             IEnumerable<EVFitting> fits = agente.SelectFitsEnShoppingList(id);

            return View(fits);
        }

        public ActionResult AddMarketItems(string id)
        {
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

            return  PartialView("PVMarketItemEnShoppingList",item);
        }


        [HttpPost()]
        [ValidateInput(false)]
        public PartialViewResult AnalyzeRawFit(string rawFit)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            IEnumerable<FittingAnalyzed> fits =
                logica.ObtenerListaFits(rawFit, Enumerados.TipoFormatoFitOriginal.EveXml);

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
            EVFitting evfit = agente.SelectFitPorID(fitID);


            return PartialView("PVFitInShoppingList", evfit);

        }


        public ActionResult DeleteFittingFromShoppingList(int id)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            agente.DeleteFitPorID(id);

            return Content(id.ToString());
            //return Json(new { Result = id });
        }
    }
}
