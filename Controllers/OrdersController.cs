using Microsoft.AspNetCore.Mvc;
using MiniGroceryOrderSystem.Services;

namespace MiniGroceryOrderSystem.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(int productId, int quantity)
    {
        try
        {
            var result = await _orderService.PlaceOrderAsync(productId, quantity);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
