using MiniGroceryOrderSystem.Data;
using MiniGroceryOrderSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniGroceryOrderSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private static readonly SemaphoreSlim _lock = new(1, 1);

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> PlaceOrderAsync(int productId, int quantity)
        {
            await _lock.WaitAsync(); // concurrency control
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

                if (product == null)
                    throw new Exception("Product not found");

                if (product.Stock < quantity)
                    throw new Exception("Insufficient stock");

                product.Stock -= quantity;

                var order = new Order
                {
                    ProductId = productId,
                    Quantity = quantity,
                    OrderDate = DateTime.UtcNow
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                return "Order placed successfully";
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}
