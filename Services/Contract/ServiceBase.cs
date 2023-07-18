using AutoMapper;
using Entities.Contracts;
using Repositories.Contracts;
namespace Services.Contract
{
    public abstract class ServiceBase<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _categoryProductRepository;
        private readonly IMapper _mapper;
        protected ServiceBase(IEntityRepository<TEntity> categoryProductRepository, IMapper mapper)
        {
            _categoryProductRepository = categoryProductRepository;
            _mapper = mapper;
        }
        public virtual IEnumerable<TEntity>? GetList(bool trackChanges = false)
        {
            return _categoryProductRepository.GetList(trackChanges);
        }
        public abstract TEntity? GetById(int id, bool trackChanges = false);
        public virtual TEntity Add(TEntity entity, bool trackChanges = false)
        {
            _categoryProductRepository.Add(entity, trackChanges);
            _categoryProductRepository.SaveChanges();
            return entity;
        }
        public virtual TEntity Update(TEntity entity, bool trackChanges = false)
        {
            _categoryProductRepository.Update(entity, trackChanges);
            _categoryProductRepository.SaveChanges();
            return entity;
        }
        public abstract void Delete(int id, bool trackChanges = false);
    }
}