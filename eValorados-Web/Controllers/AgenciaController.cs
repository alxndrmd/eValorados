using eValorados_Web.Models;
using eValorados_Web.Persistence;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eValorados_Web.Controllers
{
    public class AgenciaController : Controller
    {
        private AgenciaDAO _agenciaDAO = null;
        private AgenciaDAO AgenciaDAO
        {
            get
            {
                if (_agenciaDAO == null)
                    _agenciaDAO = new AgenciaDAO();
                return _agenciaDAO;
            }
        }
        private TipoAgenciaDAO _tipoAgenciaDAO = null;
        private TipoAgenciaDAO TipoAgenciaDAO
        {
            get
            {
                if (_tipoAgenciaDAO == null)
                    _tipoAgenciaDAO = new TipoAgenciaDAO();
                return _tipoAgenciaDAO;
            }
        }
        //
        // GET: /Agencia/
        public ActionResult Index()
        {
            var _agencias = AgenciaDAO.LoadAll();
            return View(_agencias);
        }

        //
        // GET: /Agencia/Details/5
        public ActionResult Details(int id)
        {
            var _agencia = AgenciaDAO.LoadById(id);
            return View(_agencia);
        }

        //
        // GET: /Agencia/Create
        public ActionResult Create()
        {
            ViewData["TiposAgencia"] = TipoAgenciaDAO.LoadAll();
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

        //
        // GET: /Agencia/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["TiposAgencia"] = TipoAgenciaDAO.LoadAll();
            var _agencia = AgenciaDAO.LoadById(id);
            return View(_agencia);
        }

        //
        // POST: /Agencia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Agencia agencia)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    AgenciaDAO.Update(agencia);
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
