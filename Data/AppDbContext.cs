using Microsoft.EntityFrameworkCore;
using MiniGroceryOrderSystem.Models;

namespace MiniGroceryOrderSystem.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}
