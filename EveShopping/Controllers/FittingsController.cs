using EveShopping.Logica;
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

namespace EveShopping.Controllers
{
    public class FittingsController : VSHBaseController
    {
        //
        // GET: /Fittings/

        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult MyFittings()
        {
            SetHeadCounters();

            EDVMyFittings edv = null;
            edv = GetEDVMyFittingsByUser(User.Identity.Name);

            return View(edv);

        }

        internal static EDVMyFittings GetEDVMyFittingsByUser(string userName)
        {
            EDVMyFittings edv = new EDVMyFittings();
            AgenteFittings agente = new AgenteFittings();
            IEnumerable<ShipMarketGroup> marketItems = agente.SelectMarketGroupsByParentID(4, userName);
            edv.MarketItems = marketItems;
            EDVFittingsList edvFitList = new EDVFittingsList();
            edvFitList.Fittings = new List<EVFitting>();
            edv.Fittings = edvFitList;
            return edv;
        }

        [Authorize]
        public ActionResult UseAnalysedFit(string fitName)
        {
            try
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
                AgenteShoppingList agente = new AgenteShoppingList();
                int fitID = agente.SaveAnalysedFit(null, User.Identity.Name, fit);
                AgenteFittings agenteFit = new AgenteFittings();
                int groupId = agenteFit.GetFitMarketGroupID(fitID);

                return NavigateMarketGroup(groupId, fitID, fitName);
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }

        }


        [Authorize]
        public PartialViewResult NavigateMarketGroup(int id, int selFitId = 0, string selFitName = null)
        {
            EDVMyFittings edv = CommonNavigateMarketGroup(id, selFitId, selFitName, User.Identity.Name);

            edv.Fittings.ShowUnits = false;
            edv.Fittings.ShowEdit = false;

            return PartialView("PVPersonalFittingsMenu", edv);
        }

        internal static EDVMyFittings CommonNavigateMarketGroup(int id, int selFitId, string selFitName, string userName)
        {
            EDVMyFittings edv;
            EDVFittingsList edvFitlist;

            AgenteFittings agente = new AgenteFittings();
            IEnumerable<ShipMarketGroup> marketItems = agente.SelectMarketGroupsByParentID(id, userName);
            IList<invMarketGroup> marketChain = agente.GetParentGroupsChainForShips(id);

            invMarketGroup groupActual = marketChain.Last();
            marketChain.Remove(groupActual);

            edv = new EDVMyFittings();
            edv.MarketItems = marketItems;
            edv.MarketChain = marketChain;
            edv.GroupName = groupActual.marketGroupName;
            edv.ContextSelectedFitID = selFitId;
            edv.ContextSelectedFitName = selFitName;
            edvFitlist = new EDVFittingsList();
            edv.Fittings = edvFitlist;
            edvFitlist.Fittings = agente.SelectFitsByMarketGroup(userName, groupActual.marketGroupID);

            return edv;
        }
    }
}
