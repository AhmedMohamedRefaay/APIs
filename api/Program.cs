using System;
using System.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ApiContext;
using System.Text.Json.Serialization;
using Application.Contracts;
using Infrastructure;
using Application.Features.Products.Queries.GetAllQuery;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ApiDataBase")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<DBContext>()
        .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
     
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddMediatR(config =>
{ config.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly); });
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.MapDefaultControllerRoute();
app.Run();
