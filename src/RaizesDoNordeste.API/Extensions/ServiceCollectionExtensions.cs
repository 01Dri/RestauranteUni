using System.Reflection;
using FluentValidation;
using RaizesDoNordeste.Application.Patterns.Dispatchers;
using RaizesDoNordeste.Application.Patterns.Dispatchers.Orders;
using RaizesDoNordeste.Application.Patterns.Dispatchers.Orders.Handlers;
using RaizesDoNordeste.Data;
using RaizesDoNordeste.Domain.Core.Ingredients.Enums;
using RaizesDoNordeste.Domain.Core.Orders;
using RaizesDoNordeste.Domain.Core.Users;
using RaizesDoNordeste.Domain.UseCases;

namespace RaizesDoNordeste.API.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        extension(IServiceCollection service)
        {
            public IServiceCollection AddApplicationServices(params Type[] assemblyMarkers)
            {
                var assemblies = assemblyMarkers
                    .Select(x => x.Assembly)
                    .Distinct()
                    .ToArray();

                service.RegisterImplementations(typeof(IUseCaseHandler<>), assemblies);
                service.RegisterImplementations(typeof(IUseCaseHandler<,>), assemblies);
                service.RegisterImplementations(typeof(IValidator<>), assemblies);
                return service;
            }

            public IServiceCollection AddPatterns()
            {
                service.AddDispatchers();
                return service;
            }

            private void AddDispatchers()
            {
                service.AddScoped<IOrderStatusHandler, OrderStatusReadyHandler>();
                service.AddScoped<IDispatcher<OrderStatus, Order>, OrderStatusDispatcher>(s =>
                {
                    var handlers = GetOrderStatusHandlers();
                    var currentUser = s.GetRequiredService<ICurrentUser>();
                    var applicationDbContext = s.GetRequiredService<ApplicationDbContext>();
                    return new OrderStatusDispatcher(handlers, currentUser, applicationDbContext);
                });
                
            }

            private void RegisterImplementations(Type serviceType, IEnumerable<Assembly> assemblies)
            {
                var implementations = assemblies
                    .SelectMany(x => x.GetTypes())
                    .Where(x => x is { IsClass: true, IsAbstract: false })
                    .SelectMany(implementation => implementation.GetInterfaces()
                        .Where(type => type.IsGenericType && type.GetGenericTypeDefinition() == serviceType)
                        .Select(type => new
                        {
                            Service = type,
                            Implementation = implementation
                        }));

                foreach (var implementation in implementations)
                {
                    service.AddScoped(implementation.Service, implementation.Implementation);
                }    
            }

            private static List<IOrderStatusHandler> GetOrderStatusHandlers()
            {
                var assembly = typeof(IOrderStatusHandler).Assembly;
                var implementations = assembly
                    .GetTypes()
                    .Where(t =>
                        t.IsClass &&
                        !t.IsAbstract &&
                        typeof(IOrderStatusHandler).IsAssignableFrom(t))
                    .ToList();

               return implementations
                    .Select(type => (IOrderStatusHandler)Activator.CreateInstance(type)!)
                    .ToList();
            }
        }
    }
}

