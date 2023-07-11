using Entities.Models;
using Repositories.Contracts;
namespace Repositories.Concrete
{
    public class CategoryManager : RepositoryManagerBase<Category>, ICategoryManager
    {
        public CategoryManager(IRepositoryBase<Category> repositoryBase) : base(repositoryBase) { }
    }
}
