using AutoMapper;
using Entities.Contracts;
using Entities.Dtos.ProductDtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contract;
namespace Services.Concrete
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductManager _managerBase;
        private readonly IMapper _mapper;
        public ProductService(IProductManager managerBase, IMapper mapper) : base(managerBase, mapper)
        {
            _managerBase = managerBase;
            _mapper = mapper;
        }
        public override Product? GetById(int id, bool trackChanges = false)
        {
            var entity = _managerBase.Get(p => p.ProductId.Equals(id), trackChanges);
            return entity ?? throw new Exception("Product Not Found!");
        }
        public override Product Update(Product entity, bool trackChanges = false)
        {
            var product = _managerBase.Get(p => p.ProductId.Equals(entity.ProductId), trackChanges);
            product!.ProductName = entity.ProductName;
            product.CategoryId = entity.CategoryId;
            product.UnitPrice = entity.UnitPrice;
            product.UnitsInStock = entity.UnitsInStock;
            product.QuantityPerUnit = entity.QuantityPerUnit;
            product.ReorderLevel = entity.ReorderLevel;
            product.UnitsOnOrder = entity.UnitsOnOrder;
            product.SupplierId = entity.SupplierId;
            _managerBase.SaveChanges();
            return product;
        }
        public override void Delete(int id, bool trackChanges = false)
        {
            Product? product = GetById(id, trackChanges);
            if (product == null) throw new Exception("Product Not Found!");
            _managerBase.Delete(product, trackChanges);
            _managerBase.SaveChanges();
        }
        public Product? AddWithDtoForInsertion(IDto dtoEntity, bool trackChanges = false)
        {
            Product entity = _mapper.Map<Product>(dtoEntity);
            _managerBase.Add(entity, trackChanges);
            return entity;
        }
        public ProductDtoForUpdate? UpdateWithDtoForUpdate(ProductDtoForUpdate productDto, bool trackChanges = false)
        {
            var entity = _mapper.Map<Product>(productDto);
            var product = _managerBase.Update(entity, trackChanges);
            _managerBase.SaveChanges();
            return productDto;
        }

        public ProductDtoForUpdate? GetWithDtoForUpdate(int id, bool trackChanges = false)
        {
            var product = GetById(id, trackChanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }
    }
}