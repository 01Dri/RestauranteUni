using System.Threading.Tasks;
using RaizesDoNordeste.Data;
using RaizesDoNordeste.Domain.Core.Ingredients.Enums;
using RaizesDoNordeste.Domain.Core.Orders;
using RaizesDoNordeste.Domain.Core.Users;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Application.Patterns.Dispatchers.Orders;

public interface IOrderStatusHandler
{
    OrderStatus Status { get; }
    public Task<Result> HandleAsync(Order order, ICurrentUser user, ApplicationDbContext context);
}
