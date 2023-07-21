using Entities.Dtos.Category;
using Entities.Models;

namespace Services.Contract
{
    public interface ICategoryService : IEntityService<Category>
    {
        public Category? AddWithDtoForInsertion(CategoryDtoForInsertion categoryDto, bool trackChanges = false);
        public CategoryDtoForUpdate? UpdateWithDtoForUpdate(CategoryDtoForUpdate categoryDto, bool trackChanges = false);
        public CategoryDtoForUpdate? GetWithDtoForUpdate(int id);
    }
}
