using StockCartApi.DTOs;

namespace StockCartApi.Services;

public interface IOrderService
{
    Task<(bool IsSuccess, string ErrorMessage)> CheckoutAsync(CheckoutRequestDto request);
}