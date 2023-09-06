using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc7.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("SalesWebMvc7Context");
//variavel auxiliar


//builder.Services.AddDbContext<SalesWebMvc7Context>(options =>
//    options.UseMySql((conn), builder =>
//builder.MigrationsAssembly("SalesWebMvc7")));

builder.Services.AddDbContext<SalesWebMvc7Context>(options =>
{
    options.UseMySql(conn, ServerVersion.AutoDetect(conn), builder => builder.MigrationsAssembly("SalesWebMvc7"));
});
// aqui tem um delegate com uma expressão lambda

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
