using eValorados_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion.Lambda;
using eValorados_Web.Persistence;


namespace eValorados_Web.Persistence
{
    public  class ValoradoDAO :  BaseDao<Valorado, int>
    {
        public IList<Valorado> loadValoradoByAgencia(Agencia agencia)
        {
            return CurrentSession.QueryOver<Valorado>().JoinQueryOver<Almacen>(x => x.Almacenes).Where(x => x.Agencia == agencia).List<Valorado>();
        }
    }
}