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
        public IList<String> Obtenerlistavaloradoporalmacen()
        {
            using (ISession sesion = new NHibernateHelper().OpenSession())
            {
                return sesion.CreateQuery("SELECT A.VALORADO FROM TB_ALMACEN A INNER JOIN TB_AGENCIA AG ON A.AGENCIA = AG.ID WHERE A.AGENCIA = '23'").List<String>();
                
                return sesion.QueryOver<ValoradoDAO>().    .Where(Restrictions.Eq("Agencia", Agencia)).List<ValoradoDAO>();
            }
        }

    }
}