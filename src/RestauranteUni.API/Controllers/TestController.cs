using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteUni.Data;
using RestauranteUni.Domain.Users;

namespace RestauranteUni.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ICurrentUser _currentUser;
        private readonly ApplicationDbContext _context;
        public TestController(ICurrentUser currentUser, ApplicationDbContext context)
        {
            _currentUser = currentUser;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok($"Olá {_currentUser.AccountId}");
        }
        
        [HttpGet]
        [Route("cahorro")]
        public IActionResult Test()
        {
            var menu = _context.Menus.Include(x => x.Items).
                ThenInclude(x => x.Ingredients).ThenInclude(x => x.StockIngredient)
                .FirstOrDefault(); 
            
            var items = menu.Items
                .SelectMany(x => x.Ingredients).Select(x => new
                {
                    Quantity = x.Quantity,
                    Name = x.StockIngredient.Name
                })
                .ToList();
            return Ok(items);
        }
    }
}
