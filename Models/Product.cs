namespace MiniGroceryOrderSystem.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }   // 👈 FIX
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
