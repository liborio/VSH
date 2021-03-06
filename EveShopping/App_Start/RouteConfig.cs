﻿using EveShopping.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EveShopping
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//            routes.MapRoute(
//            name: "ListNew",
//            url: "lists/New",
//            defaults: new { controller = "Lists", action = "New" });

//            routes.MapRoute(
//name: "ListCreate",
//url: "lists/Create",
//defaults: new { controller = "Lists", action = "Create" });


            routes.MapRoute(
            name: "ListView",
            url: "lists/{id}",
            defaults: new { controller = "Lists", action = "GetList" },
            constraints: new  { id = new IsGuidConstraint()  }

);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}