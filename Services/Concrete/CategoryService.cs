using AutoMapper;
using Entities.Models;
using Repositories.Contracts;
using Services.Contract;

namespace Services.Concrete
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public override Category? GetById(int id, bool trackChanges = false)
        {
            var entity = _categoryRepository.Get(c => c.CategoryId.Equals(id), trackChanges);
            return entity ?? throw new Exception("Category Not Found!");
        }
        public override void Delete(int id, bool trackChanges = false)
        {
            Category? category = _categoryRepository.Get(p => p.CategoryId.Equals(id), trackChanges);
            if (category == null) throw new Exception("Category Not Found!");
            _categoryRepository.Delete(category, trackChanges);
            _categoryRepository.SaveChanges();
        }
    }
}
