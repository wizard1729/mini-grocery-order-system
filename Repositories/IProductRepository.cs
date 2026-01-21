using MiniGroceryOrderSystem.Models;

namespace MiniGroceryOrderSystem.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    void Update(Product product);
}
