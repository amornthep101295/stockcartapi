using Microsoft.EntityFrameworkCore;
using StockCartApi.Data;
using StockCartApi.DTOs;

namespace StockCartApi.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        return await _context.Products
            .Include(p => p.Stock)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Sku = p.Sku,
                Name = p.Name,
                Price = p.Price,
                // ดึง Quantity มาด้วย ถ้าไม่มีให้เป็น 0
                StockQuantity = p.Stock != null ? p.Stock.Quantity : 0
            })
            .ToListAsync();
    }
}