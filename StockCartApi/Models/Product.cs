namespace StockCartApi.Models;

public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Stock? Stock { get; set; }
}