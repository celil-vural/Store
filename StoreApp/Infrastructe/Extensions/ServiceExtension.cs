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

        public static void ConfigureLocalization(this WebApplication application)
        {
            application.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("en-US", "tr-TR").AddSupportedUICultures("en-US", "tr-TR").SetDefaultCulture("tr-TR");
            });
        }

        /*public static void ConfigureSwagger(this WebApplication application)
        {
            application.UseSwagger();
            application.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreApp API V1");
            });
        }*/
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });
        }

        public static void ConfigureEndPoints(this WebApplication application)
        {
            application.UseEndpoints(endpoint =>
            {
                endpoint.MapAreaControllerRoute(
                    name: "Admin", areaName: "Admin", pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
                endpoint.MapControllerRoute(name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoint.MapRazorPages();
            });
        }
    }
}
