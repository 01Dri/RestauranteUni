using Microsoft.AspNetCore.Mvc;
using RestauranteUni.Domain.ValuesObjects;

namespace RestauranteUni.API.Controllers;

public class BaseController : ControllerBase
{
    protected IActionResult Error<T>(
        string message,
        T data
    )
    where T : Result
    {
        var errorResponse = data.ToErrorResponse(message);
        return StatusCode((int)data.StatusCode, errorResponse);
    }
}