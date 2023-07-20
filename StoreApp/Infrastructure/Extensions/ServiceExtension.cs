using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Concrete.EntityFramework;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlconnection"),
                    b => b.MigrationsAssembly("StoreApp"));
                options.EnableSensitiveDataLogging(true);
            });
        }

        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "StoreApp.Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true; //aynı mail adresiyle birden fazla kayıt olamaz
                // Kullanıcıların e-posta doğrulaması yapmasını gerektir
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            })
                .AddEntityFrameworkStores<RepositoryContext>()
                .AddDefaultTokenProviders();
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

        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";
            //User Manager
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            //Role Manager
            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser()
                {
                    Email = "celilvural.work@gmail.com",
                    PhoneNumber = "05533637927",
                    UserName = adminUser,
                    EmailConfirmed = true,
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                    throw new Exception("Admin user could not be created");
                var roleResult = await userManager.AddToRolesAsync(user, roleManager.Roles.Select(r => r.Name).ToList());
                if (!roleResult.Succeeded)
                    throw new Exception("Admin user could not be added to roles");
            }
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
                endpoint.MapControllers();
            });
        }
    }
}
