namespace StockCartApi.Models;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}