using StoreApp.Infrastructe.Extensions;
namespace StoreApp.Infrastructe.Config
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
