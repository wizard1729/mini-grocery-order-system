using Microsoft.EntityFrameworkCore;
using MiniGroceryOrderSystem.Data;
using MiniGroceryOrderSystem.Models;

namespace MiniGroceryOrderSystem.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }
}
