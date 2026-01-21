namespace MiniGroceryOrderSystem.Services;

public interface IOrderService
{
    Task<string> PlaceOrderAsync(int productId, int quantity);
}
