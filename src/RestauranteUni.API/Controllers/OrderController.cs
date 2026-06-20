using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteUni.Domain.Core.Orders.DTO;
using RestauranteUni.Domain.UseCases;

namespace RestauranteUni.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class OrderController : ControllerBase
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

        var error = result.ToErrorResponse("Failed to create an order");
        return StatusCode(error.Status, error);
    }
}