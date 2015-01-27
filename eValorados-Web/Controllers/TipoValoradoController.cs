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
    public class TipoValoradoController : Controller
    {
        private TipoValoradoDAO _tipoValoradoDAO = null;
        private TipoValoradoDAO TipoValoradoDAO
        {
            get
            {
                if (_tipoValoradoDAO == null)
                    _tipoValoradoDAO = new TipoValoradoDAO();
                return _tipoValoradoDAO;
            }
        }
        //
        // GET: /TipoValorado/
        public ActionResult Index()
        {
            var _tipoValorados = TipoValoradoDAO.LoadAll();
            return View(_tipoValorados);
        }

        //
        // GET: /TipoValorado/Details/5
        public ActionResult Details(int id)
        {
            var _tipoValorado = TipoValoradoDAO.LoadById(id);
            return View(_tipoValorado);
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
        public ActionResult Create(TipoValorado tipoValorado)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    TipoValoradoDAO.Create(tipoValorado);
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
            var _tipoValorado = TipoValoradoDAO.LoadById(id);
            return View(_tipoValorado);
        }

        //
        // POST: /TipoValorado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TipoValorado tipoValorado)
        {
            try
            {
                var _tipoValorado = TipoValoradoDAO.LoadById(id);
                if (_tipoValorado.IsActivo && !tipoValorado.IsActivo && _tipoValorado.Valorados.Count > 0)
                {
                    ModelState.AddModelError("CustomError", String.Format("El tipo valorado con id=[{0}] esta siendo usado y no puede desactivarse", id));
                    return View();
                }

                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    TipoValoradoDAO.Update(tipoValorado);
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
