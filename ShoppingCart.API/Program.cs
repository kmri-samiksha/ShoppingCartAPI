using ShoppingCart.API;
using ShoppingCart.Application.Services;
using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Interface;
using ShoppingCart.Domain.ShoppingCart;
using ShoppingCart.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CartTotalService>();
builder.Services.AddScoped<IProductPricingPolicy, ConfigProductPricingPolicy>();
builder.Services.Configure<ProductPricingOptions>(
    builder.Configuration.GetSection("ProductPricingOptions"));


//builder.Services.AddAppDI();

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

app.Run();
public partial class Program { }

