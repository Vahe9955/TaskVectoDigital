using Microsoft.EntityFrameworkCore;
using System;
using TaskVectoDigital.AppContext;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.



// Add services to the container.
services.AddControllersWithViews();

services.AddMvc();

// DbContext
var migrationsAssembly = "UseEffectsinPhotoApi";
var dbConnString = configuration.GetConnectionString("DefaultConnection");

void DbContextOptionsBuilder(DbContextOptionsBuilder builder)
{
    builder.UseSqlServer(dbConnString, sql =>
    {
        sql.MigrationsAssembly(migrationsAssembly);
        sql.EnableRetryOnFailure(10);
    });
}

/// When Run this Project All Migrations Hase been Used in Your Database
services.AddDbContext<ApplicationContext>(DbContextOptionsBuilder);
services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();




// For Swagger Test 

services.AddControllers();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
