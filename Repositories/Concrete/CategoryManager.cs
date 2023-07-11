using Entities.Models;
using Repositories.Contracts;
namespace Repositories.Concrete
{
    public class CategoryManager : RepositoryManager<Category>
    {
        public CategoryManager(IRepositoryBase<Category> repositoryBase) : base(repositoryBase) { }
    }
}
