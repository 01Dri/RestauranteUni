using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteUni.Domain.Core.Orders.DTO;
using RestauranteUni.Domain.UseCases;

namespace RestauranteUni.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class OrderController : BaseController
{
    private readonly IUseCaseHandler<CreateOrderDto, OrderResponseDto> _handler;

    public OrderController(IUseCaseHandler<CreateOrderDto, OrderResponseDto> handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var result = await _handler.HandleAsync(dto, cancellationToken);
        if (result.IsSuccess)
        {
            return Created("", result.Data);
        }
        return Error("Failed to create an order", result);
    }
}