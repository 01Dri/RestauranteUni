using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaizesDoNordeste.Domain.Core.Menus.DTO;
using RaizesDoNordeste.Domain.UseCases;

namespace RaizesDoNordeste.API.Controllers
{

    [ApiController]
    [Route("restaurante")]
    [Authorize]
    public class RestaurantController : ControllerBase
    {

        private readonly IUseCaseHandler<MenuResponseDto> _handler;
        public RestaurantController(IUseCaseHandler<MenuResponseDto> handler)
        {
            _handler = handler;
        }
    }
}

