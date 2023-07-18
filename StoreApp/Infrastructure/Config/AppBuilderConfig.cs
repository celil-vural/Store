using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Infrastructure.Config
{
    public static class AppBuilderConfig
    {
        public static void ConfigureBuilder(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.ConfigureIdentity();
            builder.Services.AddRazorPages();
            builder.Services.ConfigureDb(builder.Configuration);
            builder.Services.ConfigureSession();
            builder.Services.AddDependencies();
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.ConfigureRouting();
        }
    }
}
