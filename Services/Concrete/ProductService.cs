using Entities.Models;
using Repositories.Contracts;
using Services.Contract;
namespace Services.Concrete
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductManager _managerBase;
        public ProductService(IProductManager managerBase) : base(managerBase)
        {
            _managerBase = managerBase;
        }
        public override Product? GetById(int id, bool trackChanges)
        {
            var entity = _managerBase.Get(p => p.ProductId.Equals(id), trackChanges);
            return entity ?? throw new Exception("Product Not Found!");
        }
    }
}