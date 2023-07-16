using AutoMapper;
using Entities.Contracts;
using Entities.Dtos.ProductDtos;
using Entities.Models;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contract;
namespace Services.Concrete
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _repositoryBase;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repositoryBase, IMapper mapper) : base(repositoryBase, mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }
        public override Product? GetById(int id, bool trackChanges = false)
        {
            var entity = _repositoryBase.Get(p => p.ProductId.Equals(id), trackChanges);
            return entity ?? throw new Exception("Product Not Found!");
        }
        public override Product Update(Product entity, bool trackChanges = false)
        {
            var product = _repositoryBase.Get(p => p.ProductId.Equals(entity.ProductId), trackChanges);
            product!.ProductName = entity.ProductName;
            product.CategoryId = entity.CategoryId;
            product.UnitPrice = entity.UnitPrice;
            product.UnitsInStock = entity.UnitsInStock;
            product.QuantityPerUnit = entity.QuantityPerUnit;
            product.ReorderLevel = entity.ReorderLevel;
            product.UnitsOnOrder = entity.UnitsOnOrder;
            product.SupplierId = entity.SupplierId;
            _repositoryBase.SaveChanges();
            return product;
        }
        public override void Delete(int id, bool trackChanges = false)
        {
            Product? product = GetById(id, trackChanges);
            if (product == null) throw new Exception("Product Not Found!");
            _repositoryBase.Delete(product, trackChanges);
            _repositoryBase.SaveChanges();
        }
        public Product? AddWithDtoForInsertion(IDto dtoEntity, bool trackChanges = false)
        {
            Product entity = _mapper.Map<Product>(dtoEntity);
            _repositoryBase.Add(entity, trackChanges);
            return entity;
        }
        public ProductDtoForUpdate? UpdateWithDtoForUpdate(ProductDtoForUpdate productDto, bool trackChanges = false)
        {
            var entity = _mapper.Map<Product>(productDto);
            var product = _repositoryBase.Update(entity, trackChanges);
            _repositoryBase.SaveChanges();
            return productDto;
        }

        public ProductDtoForUpdate? GetWithDtoForUpdate(int id, bool trackChanges = false)
        {
            var product = GetById(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public List<Product>? GetAllProductsWithDetails(ProductRequestParameters? parameters)
        {
            return _repositoryBase.GetAllProductsWithDetails(parameters);
        }
    }
}