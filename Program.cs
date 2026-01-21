using Microsoft.EntityFrameworkCore;
using MiniGroceryOrderSystem.Data;
using MiniGroceryOrderSystem.Models;
using MiniGroceryOrderSystem.Repositories;
using MiniGroceryOrderSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// InMemory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("MiniGroceryDB"));

// 🔹 Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// 🔹 Services
builder.Services.AddScoped<IOrderService, OrderService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Seed initial products
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product { Id = 1, Name = "Apple", Price = 100, Stock = 10 },
            new Product { Id = 2, Name = "Banana", Price = 40, Stock = 20 },
            new Product { Id = 3, Name = "Milk", Price = 60, Stock = 15 }
        );

        context.SaveChanges();
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
