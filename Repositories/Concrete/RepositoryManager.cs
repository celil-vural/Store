using Entities.Contracts;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concrete
{
    public class RepositoryManager<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly IEntityRepository<TEntity> _entity;
        protected RepositoryManager(IEntityRepository<TEntity> entity)
        {
            _entity = entity;
        }
        public List<TEntity> GetList(bool trackChanges = false, Expression<Func<TEntity, bool>> filter = null)
        {
            return _entity.GetList(trackChanges, filter);
        }
        public TEntity? Get(Expression<Func<TEntity, bool>> filter, bool trackChanges = false)
        {
            return _entity.Get(filter, trackChanges);
        }
        public TEntity Add(TEntity entity, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }
        public TEntity Update(TEntity entity, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity, bool trackChanges = false)
        {
            throw new NotImplementedException();
        }
        public void SaveChanges()
        {
            _entity.SaveChanges();
        }
    }
}
