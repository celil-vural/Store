using Entities.Contracts;
using Repositories.Contracts;

namespace Services.Contract
{
    public abstract class ServiceBase<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _managerBase;
        protected ServiceBase(IEntityRepository<TEntity> managerBase)
        {
            _managerBase = managerBase;
        }
        public virtual IList<TEntity> GetList(bool trackChanges)
        {
            return _managerBase.GetList(trackChanges);
        }
        public abstract TEntity? GetById(int id, bool trackChanges);
        public virtual TEntity Add(TEntity entity, bool trackChanges = false)
        {
            _managerBase.Add(entity, trackChanges);
            _managerBase.SaveChanges();
            return entity;
        }
        public virtual TEntity Update(TEntity entity, bool trackChanges = false)
        {
            _managerBase.Update(entity, trackChanges);
            _managerBase.SaveChanges();
            return entity;
        }
        public virtual void Delete(TEntity entity, bool trackChanges = false)
        {
            _managerBase.Delete(entity, trackChanges);
        }
    }
}
