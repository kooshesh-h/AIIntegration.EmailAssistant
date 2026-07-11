using System.Net;
using System.Text.Json;

namespace AIIntegration.EmailAssistant.Api.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException exception)
            {
                await HandleExceptionAsync(
                    context,
                    exception,
                    HttpStatusCode.BadRequest,
                    exception.Message);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(
                    context,
                    exception,
                    HttpStatusCode.InternalServerError,
                    "An unexpected error occurred.");
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception,
            HttpStatusCode statusCode,
            string message)
        {
            _logger.LogError(
                exception,
                "An unhandled exception occurred. TraceId: {TraceId}",
                context.TraceIdentifier);

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = message,
                TraceId = context.TraceIdentifier
            };

            var json = JsonSerializer.Serialize(
                response,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            await context.Response.WriteAsync(json);
        }
    }
}
