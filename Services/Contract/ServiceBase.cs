using AutoMapper;
using Entities.Contracts;
using Repositories.Contracts;
namespace Services.Contract
{
    public abstract class ServiceBase<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _repositoryBase;
        private readonly IMapper _mapper;
        protected ServiceBase(IEntityRepository<TEntity> repositoryBase, IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }
        public virtual IList<TEntity>? GetList(bool trackChanges = false)
        {
            return _repositoryBase.GetList(trackChanges);
        }
        public abstract TEntity? GetById(int id, bool trackChanges = false);
        public virtual TEntity Add(TEntity entity, bool trackChanges = false)
        {
            _repositoryBase.Add(entity, trackChanges);
            _repositoryBase.SaveChanges();
            return entity;
        }
        public virtual TEntity Update(TEntity entity, bool trackChanges = false)
        {
            _repositoryBase.Update(entity, trackChanges);
            _repositoryBase.SaveChanges();
            return entity;
        }
        public abstract void Delete(int id, bool trackChanges = false);
    }
}