using Entities.Models;
using Repositories.Concrete;
using Repositories.Concrete.EntityFramework;
using Repositories.Contracts;
using Services.Concrete;
using Services.Contract;
using StoreApp.Models;

namespace StoreApp.Infrastructure.Extensions
{
    public static class IoCExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            //Session
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(SessionCart.GetCart);

            //Repository Managers
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            //Connection Repositories with Database
            services.AddScoped<IRepositoryBase<Product>, EfRepositoryBase<Product>>();
            services.AddScoped<IRepositoryBase<Category>, EfRepositoryBase<Category>>();
            services.AddScoped<IRepositoryBase<Order>, EfRepositoryBase<Order>>();

            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
