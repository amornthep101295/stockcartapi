using Microsoft.EntityFrameworkCore;
using StockCartApi.Data;
using StockCartApi.DTOs;
using StockCartApi.Models;

namespace StockCartApi.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;

    public OrderService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(bool IsSuccess, string ErrorMessage)> CheckoutAsync(CheckoutRequestDto request)
    {
        if (request.Items == null || !request.Items.Any())
            return (false, "ตะกร้าสินค้าว่างเปล่า");

        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                TotalAmount = 0
            };

            decimal totalAmount = 0;

            foreach (var item in request.Items)
            {                
                if (item.Quantity <= 0)
                    return (false, "จำนวนสินค้าต้องมากกว่า 0");

                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == item.ProductId);

                if (product == null)
                    return (false, $"ไม่พบสินค้า รหัส {item.ProductId}");
                
                var rowsAffected = await _context.Stocks
                    .Where(s => s.ProductId == item.ProductId && s.Quantity >= item.Quantity)
                    .ExecuteUpdateAsync(s => s.SetProperty(p => p.Quantity, p => p.Quantity - item.Quantity));
                
                if (rowsAffected == 0)
                {                    
                    var currentStock = await _context.Stocks.FirstOrDefaultAsync(s => s.ProductId == item.ProductId);
                    return (false, $"สินค้า '{product.Name}' มีสต๊อกไม่เพียงพอ (เหลือ {currentStock?.Quantity ?? 0})");
                }                

                var totalPrice = product.Price * item.Quantity;
                totalAmount += totalPrice;

                order.OrderDetails.Add(new OrderDetail
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price,
                    TotalPrice = totalPrice
                });
            }

            order.TotalAmount = totalAmount;
            _context.Orders.Add(order);
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return (false, $"เกิดข้อผิดพลาดในการชำระเงิน: {ex.Message}");
        }
    }
}