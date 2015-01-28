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
    public class MovimientoController : Controller
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

        public ActionResult Ajustar()
        {
            ViewData["Agencias"] = AgenciaDAO.LoadAll().Where(x => x.IsActivo == true);
            return View();
        }

        [HttpPost]
        public ActionResult Ajustar(FormCollection formCollection)
        {
            return RedirectToAction("Index", "Almacen");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult LoadValoradoByAgencia(String id)
        {
            int _id = 0;
            bool isInt = int.TryParse(id, out _id);
            if (isInt)
            {
                var _agencia = AgenciaDAO.LoadById(_id);
                if (_agencia != null)
                {
                    var _valorados = ValoradoDAO.loadValoradoByAgencia(_agencia).Select(x => new { Id = x.Id, Descripcion = x.Descripcion }).ToList();
                    return Json(_valorados, JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }
	}
}