using DataLayer.Dapper;

using Microsoft.EntityFrameworkCore;

using ShipmentApp.Application.Config;
using ShipmentApp.Infrastructure.Context;
using ShipmentApp.Infrastructure.Dapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("ShipmentDB");

builder.Services.AddDbContext<ShipmentContext>(options =>
    options
        .UseSqlServer(connection, sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: new List<int>() { });
        }));

// Dependency Injections
builder.Services.AddSingleton<IDapperConfig, DapperConfig>();
builder.Services
    .AddApplicationAssembly();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

app.MapControllers();

app.MapFallbackToFile("index.html"); ;

app.Run();
