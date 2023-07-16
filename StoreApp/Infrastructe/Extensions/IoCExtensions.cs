using Entities.Models;
using Repositories.Concrete;
using Repositories.Concrete.EntityFramework;
using Repositories.Contracts;
using Services.Concrete;
using Services.Contract;
using StoreApp.Models;

namespace StoreApp.Infrastructe.Extensions
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
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailManager, OrderDetailManager>();
            services.AddScoped<IShipperManager, ShipperManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            services.AddScoped<IEmployeeTerritoryManager, EmployeeTerritoryManager>();
            services.AddScoped<ILogManager, LogManager>();
            services.AddScoped<ISuppliersManager, SuppliersManager>();
            services.AddScoped<ITerritoryManager, TerritoryManager>();
            services.AddScoped<IRegionManager, RegionManager>();

            //Connection Repositories with Database
            services.AddScoped<IRepositoryBase<Product>, EfRepositoryBase<Product>>();
            services.AddScoped<IRepositoryBase<Category>, EfRepositoryBase<Category>>();
            services.AddScoped<IRepositoryBase<Order>, EfRepositoryBase<Order>>();
            services.AddScoped<IRepositoryBase<OrderDetail>, EfRepositoryBase<OrderDetail>>();
            services.AddScoped<IRepositoryBase<Shipper>, EfRepositoryBase<Shipper>>();
            services.AddScoped<IRepositoryBase<Customer>, EfRepositoryBase<Customer>>();
            services.AddScoped<IRepositoryBase<Employee>, EfRepositoryBase<Employee>>();
            services.AddScoped<IRepositoryBase<Log>, EfRepositoryBase<Log>>();
            services.AddScoped<IRepositoryBase<Region>, EfRepositoryBase<Region>>();
            services.AddScoped<IRepositoryBase<Supplier>, EfRepositoryBase<Supplier>>();
            services.AddScoped<IRepositoryBase<Territory>, EfRepositoryBase<Territory>>();
            services.AddScoped<IRepositoryBase<EmployeeTerritory>, EfRepositoryBase<EmployeeTerritory>>();

            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IShipperService, ShipperService>();



        }
    }
}
