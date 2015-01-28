using eValorados_Web.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eValorados_Web.Persistence
{
    public class TipoAgenciaDAO : BaseDao<TipoAgencia, int>
    {
        public IList<TipoAgencia> solouncentral() 
        {
            using (ISession sesion =new NHibernateHelper().GetCurrentSession())
            {
                return sesion.QueryOver<TipoAgencia>().Where(Restrictions.Eq("IsCentral", true)).List<TipoAgencia>();
            }
        }
    }
}