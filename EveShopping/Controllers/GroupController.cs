﻿using EveShopping.Modelo;
using EveShopping.Modelo.EV;
using EveShopping.Models;
using EveShopping.Web;
using EveShopping.Web.Agentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

            if (!agente.IsGroupListOwner(id, User.Identity.Name))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, Messages.err_notAuthorizedForPage);
            }

            IEnumerable<EVStaticList> lists =  agente.SelectStaticListsHeadersByGroupId(EstadoUsuario.CurrentListPublicId);
            EDVImportLinks edv = new EDVImportLinks { Lists = lists };
            ViewBag.ShowGroupInfo = true;

            edv.ListNavMenu = new EDPVListNavMenu<Enumerados.StepsForGroupList>(Modelo.Enumerados.StepsForGroupList.AddLists);


            return View(edv);
        }

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
            edv.allowEdit = agente.IsGroupListOwner(id, this.User.Identity == null ? null : this.User.Identity.Name);
            ViewBag.AllowDelete = false;
            ViewBag.ShowGroupInfo = true;

            edv.ListNavMenu = new EDPVListNavMenu<Enumerados.StepsForGroupList>(Modelo.Enumerados.StepsForGroupList.Summary);


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
            try
            {
                AgenteGroupLists agente = new AgenteGroupLists();
                string publicID = agente.IncludeStaticListInGroup(id, EstadoUsuario.CurrentListPublicId, User.Identity.Name, nick);
                EVStaticList ev = agente.SelectStaticListHeaderById(EstadoUsuario.CurrentListPublicId, publicID);
                ViewBag.ShowGroupInfo = true;
                ViewBag.AllowDelete = true;
                return PartialView("../Lists/PVStaticShoppingList", ev);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "We couldnt include the provided list in the group. It may not be a correct link or the provided list may not exist.");                
            }
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

        #region My assets

        public ActionResult MyAssets(string id = null)
        {
            if (id == null)
            {
                id = Guid.NewGuid().ToString();
                return RedirectToAction("New", new { id = id });
            }

            EstadoUsuario.CurrentListPublicId = id;

            EDVGroupMyAssets edv = new EDVGroupMyAssets();
            SetHeadCounters();

            ViewBag.PublicID = id;
            AgenteGroupLists agente = new AgenteGroupLists();

            edv.allowEdit = agente.IsGroupListOwner(id, this.User.Identity == null ? null : this.User.Identity.Name);

            EVListSummary summ = agente.SelectGroupListSummaryPorPublicID(id);

            edv.Summary = summ;

            edv.ListNavMenu = new EDPVListNavMenu<Enumerados.StepsForGroupList>(Modelo.Enumerados.StepsForGroupList.MyAssets);

            return View(edv);
        }


        #endregion


    }
}
