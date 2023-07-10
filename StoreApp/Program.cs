using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Concrete;
using Repositories.Concrete.EntityFramework;
using Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));
});
builder.Services.AddScoped<RepositoryManager<Product>, ProductManager>();
builder.Services.AddScoped<IEntityRepository<Product>, EfRepositoryBase<Product>>();
//builder.Services.AddScoped<IProductRepository, EfRepositoryBase<Product>>();
var app = builder.Build();

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
