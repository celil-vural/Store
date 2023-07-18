using Entities.Contracts;
using System.Linq.Expressions;

namespace Repositories.Contracts
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        IEnumerable<TEntity>? GetList(bool trackChanges = false, Expression<Func<TEntity, bool>>? filter = null);
        TEntity? Get(Expression<Func<TEntity, bool>> filter, bool trackChanges = false);
        TEntity? Add(TEntity entity, bool trackChanges = false);
        TEntity? Update(TEntity entity, bool trackChanges = false);
        void Delete(TEntity entity, bool trackChanges = false);
        void SaveChanges();
    }
}
