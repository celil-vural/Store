using Microsoft.EntityFrameworkCore;
using Repositories.Concrete.EntityFramework;

namespace StoreApp.Infrastructe.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("StoreApp"));
            });
        }

        public static void ConfigureSession(this IServiceCollection service)
        {
            service.AddDistributedMemoryCache();
            service.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }
    }
}
