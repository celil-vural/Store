using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Concrete;
using Repositories.Concrete.EntityFramework;
using Repositories.Contracts;
using Services.Concrete;
using Services.Contract;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
});
//builder.Services.AddScoped<RepositoryManagerBase<Product>, ProductManager>();
//builder.Services.AddScoped<RepositoryManagerBase<Category>, CategoryManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IRepositoryBase<Product>, EfRepositoryBase<Product>>();
builder.Services.AddScoped<IRepositoryBase<Category>, EfRepositoryBase<Category>>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
app.UseStaticFiles();
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