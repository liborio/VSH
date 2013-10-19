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

            return View();
        }

        [Authorize]
        public ActionResult Summary(string id)
        {
            SetHeadCounters();

            return View();
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
