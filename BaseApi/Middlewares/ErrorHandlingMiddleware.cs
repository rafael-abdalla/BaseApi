using BaseApi.DTOs;
using System.Net;
using System.Text.Json;

namespace BaseApi.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            HttpStatusCode code;
            ErrorResponse result;

            if (exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound;
                result = new ErrorResponse(context, exception.Message);
            }
            else if (exception is ValidationResultException)
            {
                code = HttpStatusCode.BadRequest;
                result = new ErrorResponse(context, exception.Message);
            }
            else
            {
                code = HttpStatusCode.InternalServerError;
                result = new ErrorResponse(context);
            }

            logger.LogError(JsonSerializer.Serialize(new TraceResponse(context, exception)));

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
