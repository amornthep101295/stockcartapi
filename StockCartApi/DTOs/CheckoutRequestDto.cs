using System.ComponentModel.DataAnnotations;

namespace StockCartApi.DTOs;

public class CheckoutRequestDto
{
    public List<CartItemDto> Items { get; set; } = new();
}

public class CartItemDto
{
    public Guid ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "จำนวนสินค้าต้องมากกว่า 0")]
    public int Quantity { get; set; }
}