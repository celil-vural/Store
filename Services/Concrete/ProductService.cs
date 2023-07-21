using AutoMapper;
using Entities.Dtos.Product;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contract;
namespace Services.Concrete
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryService categoryService) : base(productRepository, mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public override Product? GetById(int id, bool trackChanges = false)
        {
            var entity = _productRepository.Get(p => p.ProductId.Equals(id), trackChanges);
            return entity ?? throw new Exception("Product Not Found!");
        }
        public override Product Update(Product entity, bool trackChanges = false)
        {
            var product = _productRepository.Get(p => p.ProductId.Equals(entity.ProductId), trackChanges);
            product!.ProductName = entity.ProductName;
            product.CategoryId = entity.CategoryId;
            product.Price = entity.Price;
            _productRepository.SaveChanges();
            return product;
        }
        public override void Delete(int id, bool trackChanges = false)
        {
            Product? product = GetById(id, trackChanges);
            if (product == null) throw new Exception("Product Not Found!");
            _productRepository.Delete(product, trackChanges);
            _productRepository.SaveChanges();
        }
        public Product? AddWithDtoForInsertion(ProductDtoForInsertion productDto, bool trackChanges = false)
        {
            Product entity = _mapper.Map<Product>(productDto);
            _productRepository.Add(entity, trackChanges);
            return entity;
        }

        public ProductDtoForUpdate? UpdateWithDtoForUpdate(ProductDtoForUpdate productDto, bool trackChanges = false)
        {
            var entity = _mapper.Map<Product>(productDto);
            var product = _productRepository.Update(entity, trackChanges);
            _productRepository.SaveChanges();
            return productDto;
        }

        public ProductDtoForUpdate? GetWithDtoForUpdate(int id, bool trackChanges = false)
        {
            var product = GetById(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IEnumerable<Product>? GetAllProductsWithDetails(ProductRequestParameters? parameters)
        {
            var products = _productRepository.GetAllProductsWithDetails(parameters);

            return products;
        }

        public List<Product>? GetLastestProducts(int count, bool trackChanges = false)
        {
            return GetList()?.OrderByDescending(p => p.ProductId).Take(count).ToList();
        }

        public IEnumerable<Product>? GetShowcaseProducts(bool trackChanges = false)
        {
            var products = _productRepository.GetShowcaseProducts(trackChanges);
            return products;
        }

        public ProductDtoForUpdate? GetOneProductForUpdate(int id, bool trackChanges = false)
        {
            var product = GetById(id);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }
    }
}