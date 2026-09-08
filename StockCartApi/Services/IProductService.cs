using StockCartApi.DTOs;

namespace StockCartApi.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
}