using AutoMapper;
using Entities.Contracts;
using Repositories.Contracts;
namespace Services.Contract
{
    public abstract class ServiceBase<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _managerBase;
        private readonly IMapper _mapper;
        protected ServiceBase(IEntityRepository<TEntity> managerBase, IMapper mapper)
        {
            _managerBase = managerBase;
            _mapper = mapper;
        }
        public virtual IList<TEntity>? GetList(bool trackChanges = false)
        {
            return _managerBase.GetList(trackChanges);
        }
        public abstract TEntity? GetById(int id, bool trackChanges = false);
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
        public abstract void Delete(int id, bool trackChanges = false);
    }
}