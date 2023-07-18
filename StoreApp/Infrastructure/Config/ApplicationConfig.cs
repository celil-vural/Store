using StoreApp.Infrastructure.Extensions;
namespace StoreApp.Infrastructure.Config
{
    public static class ApplicationConfig
    {
        public static void ConfigureApp(this WebApplication app)
        {
            app.UseStaticFiles();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.ConfigureEndPoints();
            app.ConfigureLocalization();
        }
    }
}
