using System.Net;
using RaizesDoNordeste.Domain.UseCases;

namespace RaizesDoNordeste.Domain.ValuesObjects;

public class Result
{
    protected Result(
        bool isSuccess,
        IReadOnlyCollection<Validation>? validations = null,
        HttpStatusCode statusCode = HttpStatusCode.OK,
        Error? errorData = null)
    {
        IsSuccess = isSuccess;
        Validations = validations ?? [];
        StatusCode = statusCode;
        ErrorData = errorData;
    }

    public bool IsSuccess { get; }

    public IReadOnlyCollection<Validation> Validations { get; }

    public HttpStatusCode StatusCode { get; }

    public Error? ErrorData { get; }

    public static Result Success()
        => new(true);

    public static Result Success(HttpStatusCode statusCode)
        => new(true, statusCode: statusCode);

    public static Result Failure(
        IEnumerable<Validation> validations,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, validations.ToList(), statusCode);

    public static Result Failure(
        Error errorData,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(false, statusCode: statusCode, errorData: errorData);

    public static Result FailureNotFound(string errorMessage)
        => new(
            false,
            statusCode: HttpStatusCode.NotFound,
            errorData: new Error
            {
                Message = errorMessage
            });

    public ErrorResponse ToErrorResponse(string title)
        => new(
            title,
            (int)StatusCode,
            Validations,
            ErrorData);
}

public sealed class Result<T> : Result
{
    private Result(
        T? data,
        bool isSuccess,
        IReadOnlyCollection<Validation>? validations = null,
        HttpStatusCode statusCode = HttpStatusCode.OK,
        Error? errorData = null)
        : base(isSuccess, validations, statusCode, errorData)
    {
        Data = data;
    }

    public T? Data { get; }

    public static Result<T> Success(T data)
        => new(data, true);

    public static Result<T> Success(
        T data,
        HttpStatusCode statusCode)
        => new(data, true, statusCode: statusCode);

    public static Result<T> Failure(
        IEnumerable<Validation> validations,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(
            default,
            false,
            validations.ToList(),
            statusCode);

    public static Result<T> Failure(
        Error errorData,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        => new(
            default,
            false,
            statusCode: statusCode,
            errorData: errorData);

    public static Result<T> FailureNotFound(string errorMessage)
        => new(
            default,
            false,
            statusCode: HttpStatusCode.NotFound,
            errorData: new Error
            {
                Message = errorMessage
            });
}

public sealed record Validation(
    string Property,
    IReadOnlyCollection<string> Errors)
{
    public Validation(string property, string error)
        : this(property, [error])
    {
    }

    public Validation(string error)
        : this(string.Empty, [error])
    {
    }
}

public sealed class ErrorResponse
{
    public ErrorResponse(
        string title,
        int status,
        IEnumerable<Validation> validationErrors,
        Error? dynamicErrorData = null)
    {
        Title = title;
        Status = status;
        ValidationErrors = validationErrors.ToList().AsReadOnly();
        DynamicErrorData = dynamicErrorData;
        Timestamp = DateTimeOffset.UtcNow;
    }

    public string Title { get; }

    public int Status { get; }

    public DateTimeOffset Timestamp { get; }

    public IReadOnlyCollection<Validation> ValidationErrors { get; }

    public Error? DynamicErrorData { get; }
}
