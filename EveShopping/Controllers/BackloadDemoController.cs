using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EveShopping.Controllers
{
    public class BackloadDemoController : Controller
    {
        //
        // GET: /BackupDemo/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase file, FormCollection collection)
        {
            return new EmptyResult();
        }
    }
}
