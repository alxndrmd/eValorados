using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using NHibernate;
using NHibernate.Linq;
using eValorados_Web.Models;

namespace eValorados_Web.Persistence
{
    public class BaseDao<TEntity, TIdentifier>
        where TIdentifier : new()
        where TEntity : BaseModel<TIdentifier>
    {
        protected ISession CurrentSession { get; set; }

        public BaseDao()
        {
            SessionHelper sessionHelper = new SessionHelper();
            CurrentSession = sessionHelper.Current;
        }

        public TEntity LoadById(TIdentifier id)
        {
            TEntity entity = CurrentSession.Get<TEntity>(id);
            return entity;
        }

        public TIdentifier Create(TEntity entity)
        {
            TIdentifier identifier = new TIdentifier();
            identifier = (TIdentifier)CurrentSession.Save(entity);
            return identifier;
        }

        public void SaveOrUpdate(TEntity entity)
        {
            TIdentifier identifier = new TIdentifier();
            CurrentSession.SaveOrUpdate(entity);
        }

        public void Update(TEntity entity)
        {
            CurrentSession.Update(entity);
            CurrentSession.Flush();
        }

        public void Delete(TEntity entity)
        {
            CurrentSession.Delete(entity);
        }

        public void DeleteById(TIdentifier entityIdentifier)
        {
            TEntity entity = LoadById(entityIdentifier);
            CurrentSession.Delete(entity);
        }

        public IList<TEntity> LoadAll()
        {
            return CurrentSession.Query<TEntity>().ToList();
        }
    }
}