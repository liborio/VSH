using EveShopping.Logica;
using EveShopping.Web;
using EveShopping.Web.Agentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EveShopping.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public EmptyResult UpdatePrices()
        {
            double horas = (DateTime.Now - EstadoAplicacion.LastPricesUpdateTime).TotalHours;
            if (horas >= 24)
            {
                EstadoAplicacion.LastPricesUpdateTime = DateTime.Now;
                AgenteShoppingList agente = new AgenteShoppingList();
                agente.UpdatePrices();
            }
            return new EmptyResult();
        }


        public EmptyResult RefillShipGroups()
        {
            LogicaAdmin logica = new LogicaAdmin();
            logica.FillShipGroupsTable();

            return new EmptyResult();
        }

    }
}
