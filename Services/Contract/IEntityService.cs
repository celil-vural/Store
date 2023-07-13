using Entities.Contracts;

namespace Services.Contract
{
    public interface IEntityService<TEntity> where TEntity : class, IEntity, new()
    {
        IList<TEntity> GetList(bool trackChanges = false);
        TEntity? GetById(int id, bool trackChanges = false);
        TEntity Add(TEntity entity, bool trackChanges = false);
        TEntity Update(TEntity entity, bool trackChanges = false);
        void Delete(int id, bool trackChanges = false);
    }
}
