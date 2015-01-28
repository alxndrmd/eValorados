using eValorados_Web.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eValorados_Web.Controllers
{
    public class AjustesController : Controller
    {

        //
        // GET: /Ajustes/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult create() 
        {
            return View();
        }
	}
}