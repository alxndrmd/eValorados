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
    public class TipoMovimientoController : Controller
    {
        private TipoMovimientoDAO _tipoMovimientoDAO = null;
        private TipoMovimientoDAO tipoMovimientoDAO
        {
            get
            {
                if (_tipoMovimientoDAO == null)
                    _tipoMovimientoDAO = new TipoMovimientoDAO();
                return _tipoMovimientoDAO;
            }
        }
        public ActionResult Index()
        {
            var _tipomovimiento = tipoMovimientoDAO.LoadAll();
            return View(_tipomovimiento);
        }
        public ActionResult Details(int id)
        {
            var _tipomovimiento = tipoMovimientoDAO.LoadById(id);
            return View(_tipomovimiento);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TipoMovimiento tipomovimiento)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    tipoMovimientoDAO.Create(tipomovimiento);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var _tipomovimiento =tipoMovimientoDAO.LoadById(id);
            return View(_tipomovimiento);
        }
        [HttpPost]
        public ActionResult Edit(int id, TipoMovimiento tipoMovimiento)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                var _tipomovimiento = tipoMovimientoDAO.LoadById(id);
                if (!tipoMovimiento.IsActivo && _tipomovimiento.Movimientos.Count > 0)
                {
                    ModelState.AddModelError("CustomError", String.Format("El tipo movimiento con id=[{0}] esta siendo usado y no puede desactivarse.", id));
                    return View();
                }
                _sessionHelper.ClearSession();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    tipoMovimientoDAO.Update(tipoMovimiento);
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