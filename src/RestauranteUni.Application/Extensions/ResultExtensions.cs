using FluentValidation.Results;
using RestauranteUni.Domain;

namespace RestauranteUni.Application.Extensions
{
    public static class ResultExtensions
    {

        extension(ValidationResult validation)
        {
            public Result<T> ToResultFailure<T>()
            {
                var validations = new List<Validation>();
                validation.Errors.ForEach(x => validations.Add(new Validation(x.PropertyName, x.ErrorMessage)));
                return new Result<T>(validations);
            }
        }
    }
}
