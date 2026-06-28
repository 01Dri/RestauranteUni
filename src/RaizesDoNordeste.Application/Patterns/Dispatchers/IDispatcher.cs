using System.Threading.Tasks;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Application.Patterns.Dispatchers;

public interface IDispatcher<T, TK>
{
    Task<Result> HandleAsync(T parameter1, TK parameter2);
}
