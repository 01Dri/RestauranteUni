using Microsoft.AspNetCore.Mvc;
using RestauranteUni.Domain.Accounts.DTO;
using RestauranteUni.Domain.UseCases;

namespace RestauranteUni.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IUseCaseHandler<CreateAccountDto, CreateAccountResponseDto> _handler;

        public AccountController(IUseCaseHandler<CreateAccountDto, CreateAccountResponseDto> handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAccountDto dto, CancellationToken cancellation)
        {
            var result = await _handler.HandleAsync(dto, cancellation);
            if (result.IsSuccess)
            {
                return Created("", result.Data);
            }

            return BadRequest(result.Validations);
        }
    }
}
