using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestauranteUni.Data;
using RestauranteUni.Domain.Users;

namespace RestauranteUni.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RestaurantController : ControllerBase
    {

        public RestaurantController()
        {
        }

        [HttpGet]
        [Route("user/menu")]
        public async Task<IActionResult> GetUserRestaurantMenu(CancellationToken cancellation)
        {
            return Ok();
        }
    }
}
