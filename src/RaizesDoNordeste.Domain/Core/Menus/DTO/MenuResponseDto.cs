using RaizesDoNordeste.Domain.UseCases;

namespace RaizesDoNordeste.Domain.Core.Menus.DTO;

public sealed class MenuResponseDto : IUseCaseResponse
{
    public string Name { get; set; }
    public string RestaurantName { get; set; }

    public IReadOnlyCollection<MenuItemResponseDto> Items { get; set; } = [];
    public Error? ErrorResponse { get; set; }
}
