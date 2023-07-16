using StoreApp.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureDb(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.AddDependencies();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapAreaControllerRoute(
        name: "Admin", areaName: "Admin", pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");
    endpoint.MapControllerRoute(name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoint.MapRazorPages();
});
app.Run();