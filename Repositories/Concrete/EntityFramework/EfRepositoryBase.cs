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
        public List<TEntity> GetList(bool trackChanges, Expression<Func<TEntity, bool>>? filter = null)
        {
            if (filter == null) return trackChanges ? _context.Set<TEntity>().ToList() : _context.Set<TEntity>().AsNoTracking().ToList();
            return trackChanges ? _context.Set<TEntity>().Where(filter).ToList() : _context.Set<TEntity>().AsNoTracking().Where(filter).ToList();
        }
        public TEntity? Get(Expression<Func<TEntity, bool>> filter, bool trackChanges)
        {
            return trackChanges ? _context.Set<TEntity>().SingleOrDefault(filter) : _context.Set<TEntity>().AsNoTracking().SingleOrDefault(filter);
        }
        public TEntity Add(TEntity entity, bool trackChanges)
        {
            _context.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Update(TEntity entity, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
