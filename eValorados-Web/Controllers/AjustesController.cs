using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eValorados_Web.Models;
using eValorados_Web.Persistence;
using NHibernate;


namespace eValorados_Web.Controllers
{
    public class AjustesController : Controller
    {
        private AgenciaDAO _AgenciaDAO = null;
        private AgenciaDAO AgenciaDAO
        {
            get
            {
                if (_AgenciaDAO == null)
                    _AgenciaDAO = new AgenciaDAO();
                return _AgenciaDAO;
            }
        }

        private ValoradoDAO _valoradoDAO = null;
        private ValoradoDAO ValoradoDAO
        {
            get
            {
                if (_valoradoDAO == null)
                    _valoradoDAO = new ValoradoDAO();
                return _valoradoDAO;
            }
        }
        //
        // GET: /Ajustes/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        { 
            ViewData["Agencia"] = AgenciaDAO.LoadAll();
            ViewData["Valorado"] = ValoradoDAO.LoadAll();
            return View();
        }

        //
        // POST: /Agencia/Create
        [HttpPost]
        public ActionResult Create(Agencia agencia)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    AgenciaDAO.Create(agencia);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

	}
}