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
    public class ValoradoController : Controller
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
        // GET: /Valorado/
        public ActionResult Index()
        {
            var _valorados = ValoradoDAO.LoadAll();
            return View(_valorados);
        }

        //
        // GET: /Valorado/Details/5
        public ActionResult Details(int id)
        {
            var _valorado = ValoradoDAO.LoadById(id);
            return View(_valorado);
        }

        //
        // GET: /Valorado/Create
        public ActionResult Create()
        {
            //ViewData["TipoValorado"] = TipoValoradoDAO.LoadAll();//.Select(x => new SelectListItem() { Text = x.Descripcion, Value = x.Id.ToString() });
            ViewData["TipoValorado"] = ValoradoDAO.Obtenerlistavaloradoporalmacen();
            return View();
        }

        //
        // POST: /Valorado/Create
        [HttpPost]
        public ActionResult Create(Valorado valorado)
        {
            try
            {
                SessionHelper sessionHelper = new SessionHelper();
                using (ITransaction transaction = sessionHelper.Current.BeginTransaction())
                {
                    ValoradoDAO.Create(valorado);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Valorado/Edit/5
        public ActionResult Edit(int id)
        {
            SessionHelper sessionHelper = new SessionHelper();
            ViewData["TipoValorado"] = TipoValoradoDAO.LoadAll();
            Valorado valorado = ValoradoDAO.LoadById(id);
            return View(valorado);
        }

        //
        // POST: /Valorado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Valorado valorado)
        {
            try
            {
                SessionHelper sessionHelper = new SessionHelper();
                using (ITransaction transaction = sessionHelper.Current.BeginTransaction())
                {
                    ValoradoDAO.Update(valorado);
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
