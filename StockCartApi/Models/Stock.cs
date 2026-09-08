namespace StockCartApi.Models;

public class Stock
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public Product? Product { get; set; }
}