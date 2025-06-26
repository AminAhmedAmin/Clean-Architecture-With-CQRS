using Microsoft.AspNetCore.Http;

namespace VuexyBase.Application.Common.Results
{
    public class Result<T>
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        private Result(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        // Helper methods for success and failure results
        public static Result<T> Success(T data = default, string message = "Operation succeeded") =>
            new Result<T>(StatusCodes.Status200OK, message, data);

        public static Result<T> Fail( string message = "Operation failed", int statusCode = StatusCodes.Status400BadRequest) =>
            new Result<T>((int)statusCode, message, default);
    }


}
