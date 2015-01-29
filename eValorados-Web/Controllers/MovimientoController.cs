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

        private TipoMovimientoDAO _TipoMovimientoDAO = null;

        private TipoMovimientoDAO TipoMovimientoDAO
        {
            get
            {
                if (_TipoMovimientoDAO == null)
                    _TipoMovimientoDAO = new TipoMovimientoDAO();
                return _TipoMovimientoDAO;
            }
        }

        public ActionResult Ajustar()
        {
            ViewData["Agencias"] = AgenciaDAO.LoadAll().Where(x => x.IsActivo == true);
            ViewData["TipoMovimiento"] = TipoMovimientoDAO.LoadAll();
            return View();
        }

        [HttpPost]
        public ActionResult Ajustar(FormCollection formCollection)
        {
            return RedirectToAction("Index", "Almacen");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult LoadValoradoByAgencia(String AgenciaId)
        {
            int _AgenciaId = 0;
            bool isInt = int.TryParse(AgenciaId, out _AgenciaId);
            if (isInt)
            {
                var _agencia = AgenciaDAO.LoadById(_AgenciaId);
                if (_agencia != null)
                {
                    var _valorados = ValoradoDAO.loadValoradoByAgencia(_agencia).Where(x => x.IsActivo == true).Select(x => new { Id = x.Id.ToString(), Descripcion = x.Descripcion }).ToList();
                    _valorados.Insert(0, new { Id = string.Empty, Descripcion = "Seleciona un valorado" });
                    return Json(_valorados, JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }
	}
}