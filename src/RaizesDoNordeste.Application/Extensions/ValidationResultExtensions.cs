using FluentValidation.Results;
using RaizesDoNordeste.Domain.ValuesObjects;

namespace RaizesDoNordeste.Application.Extensions
{
    public static class ValidationResultExtensions
    {

        extension(ValidationResult? validation)
        {
            public Result<T> ToResultFailure<T>()
            {
                return Result<T>.Failure(
                    validation.Errors
                        .GroupBy(x => x.PropertyName)
                        .Select(group => new Validation(
                            group.Key,
                            group.Select(x => x.ErrorMessage).ToList()))
                        .ToList());
            }

            public bool ContainsErrors()
                => validation != null && validation.Errors.Count > 0;
        }
    }
}

