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
    
    public class AlmacenController : Controller
    {
        private AlmacenDAO _almacenDAO = null;
        private AlmacenDAO AlmacenDAO
        {
            get
            {
                if (_almacenDAO == null)
                    _almacenDAO = new AlmacenDAO();
                return _almacenDAO;
            }
        }
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
        // GET: /Almacen/
        public ActionResult Index()
        {
            var _almacenes = AlmacenDAO.LoadAll();
            return View(_almacenes);
        }

        //
        // GET: /Almacen/Details/5
        public ActionResult Details(int id)
        {
            var _almacen = AlmacenDAO.LoadById(id);
            return View(_almacen);
        }

        //
        // GET: /Almacen/Create
        public ActionResult Create()
        {
            ViewData["Agencias"] = AgenciaDAO.LoadAll();
            ViewData["Valorados"] = ValoradoDAO.LoadAll();
            return View();
        }

        //
        // POST: /Almacen/Create
        [HttpPost]
        public ActionResult Create(Almacen almacen)
        {
            try
            {
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {
                    AlmacenDAO.Create(almacen);
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
            ViewData["Agencias"] = AgenciaDAO.LoadAll();
            ViewData["Valorados"] = ValoradoDAO.LoadAll();
            var _almacen = AlmacenDAO.LoadById(id);
            return View(_almacen);
        }

        //
        // POST: /Almacen/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Almacen almacen)
        {
            try
            {
                var _almacen = AlmacenDAO.LoadById(id);

                
                    //prueba
                //if()

                var inventario_mayor_cant_max = almacen.CantidadMaxima < _almacen.InventarioReal && almacen.CantidadMaxima < _almacen.InventarioVirtual;
                var inventario_no_vacio = !almacen.IsActivo && (_almacen.InventarioReal > 0 || _almacen.InventarioVirtual > 0);
                
                if (inventario_mayor_cant_max || inventario_no_vacio)
                {
                    if (inventario_mayor_cant_max)
                        ModelState.AddModelError(string.Empty, String.Format("no es posible desactivar el almacen porque algun inventario sobrepasa a la cantidad maxima", id));

                    if (inventario_no_vacio)
                        ModelState.AddModelError(string.Empty, String.Format("No es posible desactivar el almacen con id=[{0}] porque todavía cuenta con inventario.", id));
                    return View();
                }
                SessionHelper _sessionHelper = new SessionHelper();
                using (ITransaction transaction = _sessionHelper.Current.BeginTransaction())
                {

                    AlmacenDAO.Update(almacen);
                    //web service 
                    

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
