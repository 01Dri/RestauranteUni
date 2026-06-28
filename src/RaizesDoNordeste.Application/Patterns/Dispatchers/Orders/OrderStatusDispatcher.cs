using System.Net;
using System.Threading.Tasks;
using RaizesDoNordeste.Data;
using RaizesDoNordeste.Domain.Core.Ingredients.Enums;
using RaizesDoNordeste.Domain.Core.Orders;
using RaizesDoNordeste.Domain.Core.Users;
using RaizesDoNordeste.Domain.UseCases;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Application.Patterns.Dispatchers.Orders;

public sealed class OrderStatusDispatcher : IDispatcher<OrderStatus, Order>
{
    private readonly Dictionary<OrderStatus, IOrderStatusHandler> _handlers;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly ICurrentUser _currentUser;

    public OrderStatusDispatcher(IEnumerable<IOrderStatusHandler> handlers, ICurrentUser currentUser, ApplicationDbContext applicationDbContext)
    {
        _currentUser = currentUser;
        _applicationDbContext = applicationDbContext;
        _handlers = handlers.ToDictionary(x => x.Status);
    }

    public async Task<Result> HandleAsync(OrderStatus parameter1, Order parameter2)
    {
        if (_handlers.TryGetValue(parameter1, out var handler))
        {
            return await handler.HandleAsync(parameter2, _currentUser, _applicationDbContext);
        }

        return Result.Failure(new Error()
        {
            Message = "Este status de pedido não possui um tratador. Por favor, contate o suporte."
            
        }, HttpStatusCode.InternalServerError);
    }
}
