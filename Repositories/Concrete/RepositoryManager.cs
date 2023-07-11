using Entities.Contracts;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concrete
{
    public abstract class RepositoryManager<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly IRepositoryBase<TEntity> _repositoryBase;
        protected RepositoryManager(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public List<TEntity> GetList(bool trackChanges = false, Expression<Func<TEntity, bool>> filter = null)
        {
            return _repositoryBase.GetList(trackChanges, filter);
        }
        public TEntity? Get(Expression<Func<TEntity, bool>> filter, bool trackChanges = false)
        {
            return _repositoryBase.Get(filter, trackChanges);
        }
        public TEntity Add(TEntity entity, bool trackChanges = false)
        {
            _repositoryBase.Add(entity, trackChanges);
            return entity;
        }
        public TEntity Update(TEntity entity, bool trackChanges = false)
        {
            _repositoryBase.Update(entity, trackChanges);
            return entity;
        }

        public void Delete(TEntity entity, bool trackChanges = false)
        {
            _repositoryBase.Delete(entity, trackChanges);
        }
        public void SaveChanges()
        {
            _repositoryBase.SaveChanges();
        }
    }
}
