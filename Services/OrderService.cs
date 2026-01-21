using Microsoft.EntityFrameworkCore;
using MiniGroceryOrderSystem.Data;
using MiniGroceryOrderSystem.Models;
using MiniGroceryOrderSystem.Repositories;

namespace MiniGroceryOrderSystem.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _productRepo;
    private readonly IOrderRepository _orderRepo;

    public OrderService(
        AppDbContext context,
        IProductRepository productRepo,
        IOrderRepository orderRepo)
    {
        _context = context;
        _productRepo = productRepo;
        _orderRepo = orderRepo;
    }

    public async Task<string> PlaceOrderAsync(int productId, int quantity)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        var product = await _productRepo.GetByIdAsync(productId);
        if (product == null)
            throw new Exception("Product not found");

        if (product.Stock < quantity)
            throw new Exception("Insufficient stock");

        product.Stock -= quantity;
        _productRepo.Update(product);

        var order = new Order
        {
            ProductId = productId,
            Quantity = quantity,
            TotalPrice = product.Price * quantity,
            CreatedAt = DateTime.UtcNow
        };

        await _orderRepo.AddAsync(order);

        await _context.SaveChangesAsync();
        await transaction.CommitAsync();

        return "Order placed successfully";
    }
}
