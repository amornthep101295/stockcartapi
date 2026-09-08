using Microsoft.AspNetCore.Mvc;
using StockCartApi.DTOs;
using StockCartApi.Services;

namespace StockCartApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("checkout")]
    public async Task<IActionResult> Checkout([FromBody] CheckoutRequestDto request)
    {
        var (isSuccess, errorMessage) = await _orderService.CheckoutAsync(request);

        if (!isSuccess)
        {
            return BadRequest(new { Message = errorMessage });
        }

        return Ok(new { Message = "ชำระเงินและตัดสต๊อกสำเร็จ" });
    }
}