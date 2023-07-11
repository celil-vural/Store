using Entities.Models;
using Repositories.Contracts;
using Services.Contract;

namespace Services.Concrete
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryManager _managerBase;
        public CategoryService(ICategoryManager managerBase) : base(managerBase)
        {
            _managerBase = managerBase;
        }

        public override Category? GetById(int id, bool trackChanges)
        {
            var entity = _managerBase.Get(c => c.CategoryId.Equals(id), trackChanges);
            return entity ?? throw new Exception("Category Not Found!");
        }
    }
}
