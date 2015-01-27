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
    public class MotivoMovimientoController : Controller
    {
        //
        // GET: /MotivoMovimiento/
        private MotivoMovimientoDAO _motivoMovimientoDAO = null;
        private MotivoMovimientoDAO MotivoMovimientoDAO
        {
            get
            {
                if (_motivoMovimientoDAO == null)
                    _motivoMovimientoDAO = new MotivoMovimientoDAO();
                return _motivoMovimientoDAO;
            }
        }
        
        //
        // GET: /MotivoMovimiento/
        public ActionResult Index()
        {
            var _MotivoMovimiento = MotivoMovimientoDAO.LoadAll();
            return View(_MotivoMovimiento);
        }

        //
        // GET: /MotivoMovimiento/Details/5
        public ActionResult Details(int id)
        {
            var _MotivoMovimiento = MotivoMovimientoDAO.LoadById(id);
            return View(_MotivoMovimiento);
        }

        //
        // GET: /MotivoMovimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Almacen/Create
        [HttpPost]
        public ActionResult Create(MotivoMovimiento MotivoMovimiento)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    MotivoMovimientoDAO.Create(MotivoMovimiento);
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
        // GET: /Almacen/Edit/5
        public ActionResult Edit(int id)
        {

            var _MotivoMovimiento = MotivoMovimientoDAO.LoadById(id);
            return View(_MotivoMovimiento);
        }

        //
        // POST: /Almacen/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MotivoMovimiento MotivoMovimiento)
        {
            try
            {
                var _MotivoMovimiento = MotivoMovimientoDAO.LoadById(id);
                if (!MotivoMovimiento.IsActivo && MotivoMovimiento.Movimientos.Count > 0)
                {
                    ModelState.AddModelError("CustomError", String.Format("No es posible desactivar el MotivoMovimiento con id=[{0}] porque todavía cuenta con Movimiento.", id));
                    return View();
                }
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    MotivoMovimientoDAO.Update(MotivoMovimiento);
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