using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using SalesWebMvc7.Data;
using SalesWebMvc7.Services;
using System.Globalization;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("SalesWebMvc7Context");
//variavel auxiliar

builder.Services.AddDbContext<SalesWebMvc7Context>(options =>
{
    options.UseMySql(conn, ServerVersion.AutoDetect(conn), builder => builder.MigrationsAssembly("SalesWebMvc7"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// SERVIÇOS FEITOS POR MIM
builder.Services.AddScoped<SeedingService>();       // isso registra o serviço no sistema de injeção de dependencia da aplicação
builder.Services.AddScoped<SellerService>();        // agora esse serviço pode ser injetado em outras classes
builder.Services.AddScoped<DepartmentService>();   
builder.Services.AddScoped<SalesRecordService>();

var app = builder.Build();

app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

// DEFININDO A LOCALIZAÇÃO
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

app.UseRequestLocalization(localizationOptions);

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
