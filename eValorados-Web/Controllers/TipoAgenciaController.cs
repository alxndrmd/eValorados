using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eValorados_Web.Controllers
{
    public class TipoAgenciaController : Controller
    {
        //
        // GET: /TipoAgencia/
        public ActionResult Index()
        {
            //var _tipoValorados = TipoValoradoDAO.LoadAll();
            return View();
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