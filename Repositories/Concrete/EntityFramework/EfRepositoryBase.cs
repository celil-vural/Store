using Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System.Linq.Expressions;

namespace Repositories.Concrete.EntityFramework
{
    public class EfRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly RepositoryContext _context;
        public EfRepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public IEnumerable<TEntity>? GetList(bool trackChanges, Expression<Func<TEntity, bool>>? filter = null)
        {
            var query = trackChanges ? _context.Set<TEntity>().AsQueryable() : _context.Set<TEntity>().AsNoTracking();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.ToList();
        }
        public TEntity? Get(Expression<Func<TEntity, bool>> filter, bool trackChanges)
        {
            var query = trackChanges ? _context.Set<TEntity>().AsQueryable() : _context.Set<TEntity>().AsNoTracking();
            return query.SingleOrDefault(filter);
        }
        public TEntity Add(TEntity entity, bool trackChanges)
        {
            var entry = _context.Set<TEntity>().Add(entity);
            return entry.Entity;
        }

        public TEntity Update(TEntity entity, bool trackChanges)
        {
            var entry = _context.Set<TEntity>().Update(entity);
            return entry.Entity;
        }

        public void Delete(TEntity entity, bool trackChanges)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
