using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MushroomSupplier.Application.Mapping;
using MushroomSupplier.Application.Services;
using MushroomSupplier.Core.Models;
using MushroomSupplier.WebAPI.Middleware;
using MushroomSupplier.Infrastructure.Data;
using MushroomSupplier.Infrastructure.Repositories;
using MushroomSupplier.Core.Interfaces;



var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                     .AddEnvironmentVariables();


builder.Services.AddDbContext<MushroomContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IRepository<Restaurant>, Repository<Restaurant>>();
builder.Services.AddScoped<IRepository<Supplier>, Repository<Supplier>>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
// builder.Services.AddAutoMapper(cfg =>
// {
//     cfg.AddProfile<AutoMapperProfile>();
// });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


//app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();