using Entities.Contracts;
using Entities.Dtos.CategoryDtos;
using Entities.Models;

namespace Services.Contract
{
    public interface ICategoryService : IEntityService<Category>
    {
        public Category AddWithDtoForInsertion(IDto dtoEntity, bool trackChanges = false);
        public CategoryDtoForUpdate UpdateWithDtoForUpdate(CategoryDtoForUpdate productDto, bool trackChanges = false);
        public CategoryDtoForUpdate GetWithDtoForUpdate(int id, bool trackChanges = false);
    }
}
