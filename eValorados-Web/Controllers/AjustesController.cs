using eValorados_Web.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eValorados_Web.Models;

namespace eValorados_Web.Controllers
{
    public class AjustesController : Controller
    {
        //
        // GET: /Ajustes/

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

        private TipoMovimientoDAO _tipoMovimientoDAO = null;
        private TipoMovimientoDAO TipoMovimientoDAO
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
            return View();
        }
        public ActionResult Ajustar(Agencia agencia)
        {
            ViewData["Agencias"] = AgenciaDAO.LoadAll();
            ViewData["Valorados"] = ValoradoDAO.loadValoradoByAgencia(agencia);
            ViewData["TipoMovimiento"] = TipoMovimientoDAO.LoadAll();

            return View();



        }
    }
}