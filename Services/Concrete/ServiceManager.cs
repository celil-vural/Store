using Services.Contract;

namespace Services.Concrete
{
    public class ServiceManager : IServiceManager
    {
        public ServiceManager(ICategoryService categoryService, IProductService productService)
        {
            CategoryService = categoryService;
            ProductService = productService;
        }

        public IProductService ProductService { get; }
        public ICategoryService CategoryService { get; }
    }
}
