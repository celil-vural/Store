using AutoMapper;
using Entities.Contracts;
using Entities.Dtos.CategoryDtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contract;

namespace Services.Concrete
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryManager _managerBase;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryManager managerBase, IMapper mapper) : base(managerBase, mapper)
        {
            _managerBase = managerBase;
            _mapper = mapper;
        }

        public override Category? GetById(int id, bool trackChanges)
        {
            var entity = _managerBase.Get(c => c.CategoryId.Equals(id), trackChanges);
            return entity ?? throw new Exception("Category Not Found!");
        }
        public override void Delete(int id, bool trackChanges = false)
        {
            Category? category = _managerBase.Get(p => p.CategoryId.Equals(id), trackChanges);
            if (category == null) throw new Exception("Category Not Found!");
            _managerBase.Delete(category, trackChanges);
            _managerBase.SaveChanges();
        }
        public Category AddWithDtoForInsertion(IDto dtoEntity, bool trackChanges = false)
        {
            Category entity = _mapper.Map<Category>(dtoEntity);
            _managerBase.Add(entity, trackChanges);
            return entity;
        }
        public CategoryDtoForUpdate UpdateWithDtoForUpdate(CategoryDtoForUpdate productDto, bool trackChanges = false)
        {
            var entity = _mapper.Map<Category>(productDto);
            var product = _managerBase.Update(entity, trackChanges);
            _managerBase.SaveChanges();
            return productDto;
        }

        public CategoryDtoForUpdate GetWithDtoForUpdate(int id, bool trackChanges = false)
        {
            var product = GetById(id, trackChanges);
            var productDto = _mapper.Map<CategoryDtoForUpdate>(product);
            return productDto;
        }
    }
}
