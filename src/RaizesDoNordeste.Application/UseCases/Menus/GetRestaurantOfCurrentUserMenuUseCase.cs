using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Data;
using RaizesDoNordeste.Domain.Core.Menus.DTO;
using RaizesDoNordeste.Domain.Core.Users;
using RaizesDoNordeste.Domain.UseCases;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Application.UseCases.Restaurants.Menus
{
     public sealed class GetRestaurantOfCurrentUserMenuUseCase  : IUseCaseHandler<MenuResponseDto>
     {
         private readonly ICurrentUser _currentUser;
         private readonly ApplicationDbContext _context;
         public GetRestaurantOfCurrentUserMenuUseCase(ICurrentUser currentUser, ApplicationDbContext context)
         {
             _currentUser = currentUser;
             _context = context;
         }

         public async Task<Result<MenuResponseDto>> HandleAsync(CancellationToken cancellation = default)
         {
             var menu = await _context.Menus
                 .Include(x => x.Restaurant)
                 .Include(x => x.Items
                     .Where(i => i.IsAvailable))
                 .FirstOrDefaultAsync(x => x.RestaurantId == _currentUser.RestaurantId, cancellation);
             if (menu == null)
             {
                 return Result<MenuResponseDto>.FailureNotFound("Cardápio não encontrado.");
             }

             var items = menu
                 .Items.OrderBy(x => x.DisplayOrder)
                 .Select(x => new MenuItemResponseDto()
             {
                 PublicId = x.PublicId,
                 Title = x.Title,
                 Description = x.Description,
                 Price = x.Price,
                 ImageUrl = x.ImageUrl,
                 IsAvailable = x.IsAvailable,
                 PreparationTimeInMinutes = x.PreparationTimeInMinutes,
                 IsFeatured = x.IsFeatured
             }).ToList();

             return Result<MenuResponseDto>.Success(new MenuResponseDto()
             {
                 Name = menu.Name,
                 RestaurantName = menu.Restaurant!.Name,
                 Items =  items
             });
     }
    }
}

