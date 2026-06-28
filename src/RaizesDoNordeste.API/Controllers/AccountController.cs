using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Domain.Core.Accounts.DTO;
using RaizesDoNordeste.Domain.UseCases;

namespace RaizesDoNordeste.API.Controllers
{
    [ApiController]
    [Route("conta")]
    public class AccountController : ControllerBase
    {

        private readonly IUseCaseHandler<CreateAccountDto, CreateAccountUseCaseResponseDto> _handler;

        public AccountController(IUseCaseHandler<CreateAccountDto, CreateAccountUseCaseResponseDto> handler)
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

