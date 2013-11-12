using EveShopping.Logica;
using EveShopping.Modelo;
using EveShopping.Modelo.EntidadesAux;
using EveShopping.Modelo.EV;
using EveShopping.Modelo;
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
    public class ListsController : VSHBaseController
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
            SetHeadCounters();
            return View();
        }

        public ActionResult Create(string slName, string slDescription)
        {
            if (!Request.Form.AllKeys.Contains("btnCreateGroupList"))
            {
                return CreateShoppingList(slName, slDescription);
            }
            else
            {
                return CreateGroupShoppingList(slName, slDescription);
            }
        }

        private ActionResult CreateShoppingList(string slName, string slDescription)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            string userName = null;
            if (Request.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            string id = agente.CrearShoppingList(slName, slDescription, userName);

            return RedirectToAction("ImportFits", new { id = id });
        }

        [Authorize]
        private ActionResult CreateGroupShoppingList(string slName, string slDescription)
        {
            AgenteGroupLists agente = new AgenteGroupLists();
            string userName = null;
            if (Request.IsAuthenticated)
            {
                userName = User.Identity.Name;
            }
            string id = agente.CreateGroupList(userName, slName, slDescription);

            return RedirectToAction("ImportLinks", "Group", new { id = id });
        }

        [HttpPost]
        public ActionResult DeleteShoppingList(string id)
        {
            try
            {
                AgenteShoppingList agente =
                    new AgenteShoppingList();
                string userName = null;
                if (Request.IsAuthenticated)
                {
                    userName = User.Identity.Name;
                }
                agente.DeleteShoppingList(id, userName);
                return new EmptyResult();

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "The shopping list doesnt exist or you don't have the right to delete it.");
            }
        }



        [HttpPost]
        public ActionResult SaveShoppingListHeader(string slName, string slDescription)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            string publicID = EstadoUsuario.CurrentListPublicId;

            agente.ActualizarShoppingListHeader(publicID, slName, slDescription);
            return new EmptyResult();
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

            AgenteShoppingList agente =
                new AgenteShoppingList();

            //Guardamos la shopping list en las de un usuario si se indica en la url
            agente.SaveListInMyListsIfProceed(this.Request, this.User.Identity, id);

            //cargamos las fits que puedan estar agregadadas a la shopping list
            IEnumerable<EVFitting> fits = agente.SelectFitsEnShoppingList(id);

            EDVImportFits edv = new EDVImportFits();
            SetHeadCounters();
            edv.allowEdit = agente.IsShoppingListOwner(EstadoUsuario.CurrentListPublicId, this.User.Identity == null ? null : this.User.Identity.Name);

            EDVFittingsList edvFitList = new EDVFittingsList();
            edvFitList.Fittings = fits;
            edv.Fittings = edvFitList;
            edv.IsShoppingListFree = agente.IsShoppingListFree(id);

            if (Request.IsAuthenticated)
            {
                EDVMyFittings edvmyfit = FittingsController.GetEDVMyFittingsByUser(User.Identity.Name);
                edv.MyFittings = edvmyfit;
                SetupFitListForImportMenu(edvmyfit.Fittings);
            }

            return View(edv);
        }

        [HttpPost]
        public JsonResult FileUpload()
        {
            HttpPostedFileBase myFile = Request.Files[0];
            bool isUploaded = false;
            string message = "File upload failed";

            if (myFile != null && myFile.ContentLength != 0)
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(myFile.InputStream))
                {
                    message = reader.ReadToEnd();
                    isUploaded = true;
                }
            }
            return Json(new { message = message });
        }

        [Authorize]
        public ActionResult NavigateMyFittingsMenu(int id, int selFitId = 0, string selFitName = null)
        {
            EDVMyFittings edv = FittingsController.CommonNavigateMarketGroup(id, selFitId, selFitName, User.Identity.Name);
            SetupFitListForImportMenu(edv.Fittings);

            return PartialView("../Fittings/PVPersonalFittingsMenu", edv);
        }

        private void SetupFitListForImportMenu(EDVFittingsList edv)
        {
            if (edv != null)
            {
                edv.ShowPriceAndVolume = false;
                edv.ShowUnits = false;
                edv.ShowUse = true;
                edv.ShowEdit = false;
                edv.ShowDelete = false;
                edv.ShowExport = false;
                edv.DivID = "myFitList";
            }
        }

        public ActionResult GetList(string id)
        {
            SetHeadCounters();


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
                //Guardamos la shopping list en las de un usuario si se indica en la url
                agente.SaveListInMyListsIfProceed(this.Request, this.User.Identity, id);
                edv.IsShoppingListFree = agente.IsShoppingListFree(id);
                return View("Summary", edv);
            }
            else
            {
                return View("Public", edv);
            }


        }

        [Authorize]
        public ActionResult MyLists()
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            IEnumerable<EVShoppingListHeader> lists =
                agente.SelectShoppingListsByUserName(User.Identity.Name);
            AgenteGroupLists agenteGroup = new AgenteGroupLists();
            IEnumerable<EVShoppingListHeader> groupLists =
                agenteGroup.SelectGroupListsByUserName(User.Identity.Name);
            EDVMyLists edv = new EDVMyLists()
            {
                Lists = lists,
                GroupLists = groupLists
            };
            SetHeadCounters();
            return View(edv);
        }

        public ActionResult Summary(string id = null)
        {
            if (id == null)
            {
                id = EstadoUsuario.CurrentListPublicId;
            }
            EstadoUsuario.CurrentListPublicId = id;

            EDVSummary edv = new EDVSummary();
            SetHeadCounters();


            ViewBag.PublicID = id;
            AgenteShoppingList agente = new AgenteShoppingList();

            edv.allowEdit = agente.IsShoppingListOwner(EstadoUsuario.CurrentListPublicId, this.User.Identity == null ? null : this.User.Identity.Name);

            //Guardamos la shopping list en las de un usuario si se indica en la url
            agente.SaveListInMyListsIfProceed(this.Request, this.User.Identity, id);

            EVListSummary summ = agente.SelectListSummaryPorPublicID(id);

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string itemArray = serializer.Serialize(summ.Items);

            edv.StaticLists = agente.SelectStaticListsByShoppingListPublicID(id);

            edv.ItemArray = itemArray;
            edv.Summary = summ;
            edv.IsShoppingListFree = agente.IsShoppingListFree(id);

            return View(edv);
        }

        public ActionResult Static(string id )
        {
            SetHeadCounters();
            EDVStatic list = new EDVStatic();
            AgenteShoppingList agente = new AgenteShoppingList();
            list.StaticLists = agente.SelectStaticListByPublicID(id);
            
            return View(list);
        }

        public ActionResult GetShoppingListsByListPublicIDMyLists(string id)
        {
            ViewBag.AllowDelete = false;
            return GetShoppingListsByListPublicID(id);
        }

        public ActionResult GetShoppingListsByListPublicID(string id)
        {
            AgenteShoppingList agente =
                new AgenteShoppingList();
            IEnumerable<EVStaticList> sslist = agente.SelectStaticListsByShoppingListPublicID(id);

            return PartialView("PVStaticShoppingLists", sslist);
        }

        public ActionResult NewStaticShoppingList()
        {
            AgenteShoppingList agente =
                new AgenteShoppingList();
            agente.CreateStaticShoppingList(EstadoUsuario.CurrentListPublicId);
            return GetShoppingListsByListPublicID(EstadoUsuario.CurrentListPublicId);
        }

        [HttpPost]
        public ActionResult DeleteStaticShoppingList(string id)
        {
            try
            {
                AgenteShoppingList agente =
                    new AgenteShoppingList();
                string userName = null;
                if (Request.IsAuthenticated)
                {
                    userName = User.Identity.Name;
                }
                agente.DeleteStaticShoppingList(id, userName);
                return GetShoppingListsByListPublicID(EstadoUsuario.CurrentListPublicId);

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "The static list doesnt exist or you don't have the right to delete it.");
            }
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


        //public JsonResult SummaryData(string id = null)
        //{
        //    AgenteShoppingList agente = new AgenteShoppingList();
        //    EVListSummary summ = agente.SelectListSummaryPorPublicID(id);

        //    return Json(summ.Items, JsonRequestBehavior.AllowGet);
        //}


        [HttpPost()]
        [ValidateInput(false)]
        public ActionResult AnalyzeRawFit(string rawFit)
        {
            LogicaShoppingLists logica =
                new LogicaShoppingLists();
            IEnumerable<FittingAnalyzed> fits = null;
            try
            {
                fits = logica.ObtenerListaFits(rawFit);
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "The fitting cant be analysed, doesnt seem to have a recognized format.");
            }

            IDictionary<string, FittingAnalyzed> diccFits =
                new Dictionary<string, FittingAnalyzed>();

            foreach (var fit in fits)
            {
                fit.Items = fit.Items.OrderBy(i => i.Slot).ToList();
                diccFits[fit.Name] = fit;
            }

            Session["lastAnalysedFits"] = diccFits;

            EDVAnalysedFitList edv = new EDVAnalysedFitList();
            edv.Fittings = fits;
            edv.UseText = "Use fit";

            if (Request.UrlReferrer.AbsolutePath.Contains("MyFittings"))
            {
                edv.ControllerName = "Fittings";
            }
            else
            {
                edv.ControllerName = "Lists";
            }


            return PartialView("../Shared/AnalyzedFitList", edv);
        }

        public ActionResult UseFitInMyList(int id)
        {
            try
            {
                AgenteShoppingList agente =
                    new AgenteShoppingList();

                agente.UseFitInList(EstadoUsuario.CurrentListPublicId, id);

                EVFitting evfit = agente.SelectFitPorID(EstadoUsuario.CurrentListPublicId, id);

                return PartialView("PVFitInShoppingList", evfit);

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ex.Message);

            }



        }


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
                string userName = null;
                if (Request.IsAuthenticated)
                {
                    userName = User.Identity.Name;
                }
                int fitID;
                EVFitting evfit = null;
                try
                {
                    fitID = agente.SaveAnalysedFit(EstadoUsuario.CurrentListPublicId, userName, fit);
                    evfit = agente.SelectFitPorID(EstadoUsuario.CurrentListPublicId, fitID);
                }
                catch (Exception ex)
                {

                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ex.Message);
                }

                return PartialView("PVFitInShoppingList", evfit);

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [HttpPost()]
        public PartialViewResult SetUnitsToFitInShoppingList(int id, int units)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            string publicID = EstadoUsuario.CurrentListPublicId;

            EVFitting evfit = agente.SetUnitsToFitInShoppingList(publicID, id, units);

            return PartialView("PVFitInShoppingList", evfit);
        }

        public ActionResult DeleteFittingFromShoppingList(int id)
        {
            string publicID = EstadoUsuario.CurrentListPublicId;
            AgenteShoppingList agente = new AgenteShoppingList();
            agente.DeleteFitPorID(publicID, id);

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



            //Guardamos la shopping list en las de un usuario si se indica en la url
            agenteShList.SaveListInMyListsIfProceed(this.Request, this.User.Identity, id);


            IEnumerable<EVMarketItem> marketItems = agente.SelectMarketGroupsByParentID(null);
            IEnumerable<MarketItem> marketItemsEnShoppingList = agenteShList.SelectMarketItemsEnShoppingList(id);
            EDVAddMarketItems edv = new EDVAddMarketItems();
            edv.allowEdit = agenteShList.IsShoppingListOwner(EstadoUsuario.CurrentListPublicId, this.User.Identity == null ? null : this.User.Identity.Name);
            SetHeadCounters();
            edv.MarketItems = marketItems;
            edv.IsShoppingListFree = agenteShList.IsShoppingListFree(id);
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

        public PartialViewResult UpdateMarketItemToShoppingList(int id, int units = 1)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            MarketItem item = agente.AddOrUpdateMarketItemEnShoppingList(EstadoUsuario.CurrentListPublicId, id, units);

            return PartialView("PVMarketItemEnShoppingList", item);
        }

        public EmptyResult UpdateDeltaInSummary(int id, int units = 0)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            agente.UpdateDeltaToSummary(EstadoUsuario.CurrentListPublicId, id, units);

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult ClearAllDelta(string id)
        {
            try
            {
                AgenteShoppingList agente = new AgenteShoppingList();
                agente.ClearAllDeltaInSummary(id);
                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        public ActionResult DeleteMarketItemToShoppingList(int id)
        {
            AgenteShoppingList agente = new AgenteShoppingList();
            agente.DeleteMarketItemEnShoppingList(EstadoUsuario.CurrentListPublicId, id);

            return null;
        }


        #endregion


                
    }
}
