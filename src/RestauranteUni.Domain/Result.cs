using System.Net;

namespace RestauranteUni.Domain
{
    public class Result
    {
        protected Result(
            bool isSuccess,
            IReadOnlyCollection<Validation>? validations = null,
            HttpStatusCode? statusCode = null)
        {
            IsSuccess = isSuccess;
            Validations = validations ?? [];
            StatusCode = statusCode;
        }

        public bool IsSuccess { get; }

        public IReadOnlyCollection<Validation> Validations { get; }

        public HttpStatusCode? StatusCode { get; }

        public static Result Success()
            => new(true);

        public static Result Failure(
            IEnumerable<Validation> validations,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(false, validations.ToList(), statusCode);

        public ErrorResponse ToErrorResponse(string title)
            => new(
                title,
                (int)(StatusCode ?? HttpStatusCode.BadRequest),
                Validations);
    }

    public sealed class Result<T> : Result
    {
        private Result(
            T? data,
            bool isSuccess,
            IReadOnlyCollection<Validation>? validations = null,
            HttpStatusCode? statusCode = null)
            : base(isSuccess, validations, statusCode)
        {
            Data = data;
        }

        public T? Data { get; }

        public static Result<T> Success(T data)
            => new(data, true);

        public static Result<T> Failure(
            IEnumerable<Validation> validations,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(default, false, validations.ToList(), statusCode);
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
            IEnumerable<Validation> errors)
        {
            Title = title;
            Status = status;
            Errors = errors.ToList().AsReadOnly();
            Timestamp = DateTimeOffset.UtcNow;
        }

        public string Title { get; }

        public int Status { get; }

        public DateTimeOffset Timestamp { get; }

        public IReadOnlyCollection<Validation> Errors { get; }
    }
}