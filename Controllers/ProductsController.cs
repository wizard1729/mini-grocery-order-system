using Microsoft.AspNetCore.Mvc;
using MiniGroceryOrderSystem.Repositories;

namespace MiniGroceryOrderSystem.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepo;

    public ProductsController(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productRepo.GetAllAsync();
        return Ok(products);
    }
}
