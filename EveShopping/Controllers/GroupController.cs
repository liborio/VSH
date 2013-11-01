using EveShopping.Modelo.EV;
using EveShopping.Models;
using EveShopping.Web;
using EveShopping.Web.Agentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveShopping.Controllers
{
    public class GroupController : VSHBaseController
    {
        //
        // GET: /Group/

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult ImportLinks(string id)
        {
            SetHeadCounters();
            this.ViewBag.PublicID = id;

            AgenteGroupLists agente = new AgenteGroupLists();
            IEnumerable<EVStaticList> lists =  agente.SelectStaticListsHeadersByGroupId(EstadoUsuario.CurrentListPublicId);
            EDVImportLinks edv = new EDVImportLinks { Lists = lists };
            ViewBag.ShowGroupInfo = true;
            return View(edv);
        }

        [Authorize]
        public ActionResult Summary(string id)
        {
            SetHeadCounters();
            this.ViewBag.PublicID = id;

            AgenteGroupLists agente = new AgenteGroupLists();
            EVListSummary ev = agente.SelectGroupListSummaryPorPublicID(id);
            EDVGroupSummary edv = new EDVGroupSummary();
            edv.Summary = ev;
            edv.Summary.ShowDelta = false;

            IEnumerable<EVStaticList> lists = agente.SelectStaticListsHeadersByGroupId(id);
            edv.Lists = lists;
            ViewBag.AllowDelete = false;
            ViewBag.ShowGroupInfo = true;
            return View(edv);
        }

        [Authorize]
        [HttpPost]
        public ActionResult RemoveListFromGroup(string id)
        {
            AgenteGroupLists agente = new AgenteGroupLists();
            try
            {
                agente.RemoveListFromGroup(EstadoUsuario.CurrentListPublicId, id, User.Identity.Name);
                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult SaveGroupListHeader(string slName, string slDescription){
            AgenteGroupLists agente = new AgenteGroupLists();
            string publicID = EstadoUsuario.CurrentListPublicId;

            agente.ActualizarGroupListHeader(publicID, User.Identity.Name, slName, slDescription);
            return new EmptyResult();
        }

        [Authorize]
        public ActionResult IncludeStaticListInGroup(string id, string nick)
        {
            AgenteGroupLists agente = new AgenteGroupLists();
            agente.IncludeStaticListInGroup(id, EstadoUsuario.CurrentListPublicId, User.Identity.Name, nick);
            EVStaticList ev = agente.SelectStaticListHeaderById(EstadoUsuario.CurrentListPublicId, id);
            ViewBag.ShowGroupInfo = true;
            ViewBag.AllowDelete = true;
            return PartialView("../Lists/PVStaticShoppingList", ev);
        }   

        [Authorize]
        public ActionResult DeleteList(string id)
        {
            try
            {
                AgenteGroupLists agente =
                    new AgenteGroupLists();
                string userName = null;
                if (Request.IsAuthenticated)
                {
                    userName = User.Identity.Name;
                }
                agente.DeleteList(userName, id);
                return new EmptyResult();

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "The group shopping list doesnt exist or you don't have the right to delete it.");
            }
        }


    }
}
