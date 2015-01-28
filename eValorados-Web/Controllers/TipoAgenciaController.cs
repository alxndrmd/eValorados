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
    public class TipoAgenciaController : Controller
    {
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
        // GET: /TipoAgencia/
        public ActionResult Index()
        {
            var _tipoAgencia = TipoAgenciaDAO.LoadAll();
            return View(_tipoAgencia);
        }

        //
        // GET: /TipoValorado/Details/5
        public ActionResult Details(int id)
        {
            var _tipoAgencia = TipoAgenciaDAO.LoadById(id);
            return View(_tipoAgencia);
        }

        //
        // GET: /TipoValorado/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoValorado/Create
        [HttpPost]
        public ActionResult Create(TipoAgencia tipoAgencia)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    TipoAgenciaDAO.Create(tipoAgencia);
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
        // GET: /TipoValorado/Edit/5
        public ActionResult Edit(int id)
        {
            var _TipoAgencia = TipoAgenciaDAO.LoadById(id);
            return View(_TipoAgencia);
        }

        //
        // POST: /TipoValorado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoAgencia TipoAgencia)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                var _TipoAgencia = TipoAgenciaDAO.LoadById(id);
                if (!TipoAgencia.IsActivo && _TipoAgencia.Agencias.Count > 0)
                {
                    ModelState.AddModelError("CustomError", String.Format("El TipoAgencia cons id=[{0}] esta siendo usado y no puede desactivarse.", id));
                    return View();
                }


                var a =TipoAgenciaDAO.solouncentral();
                if (a.Count > 0)
                {
                    ModelState.AddModelError("CustomError", String.Format("Solo puede haber una agencia central."));
                    return View();
                }


                _sessionHelper.ClearSession();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    TipoAgenciaDAO.Update(TipoAgencia);
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