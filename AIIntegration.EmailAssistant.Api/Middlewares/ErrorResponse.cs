namespace AIIntegration.EmailAssistant.Api.Middlewares
{
    public class ErrorResponse
    {
        public int StatusCode { get; init; }

        public string Message { get; init; } = string.Empty;

        public string TraceId { get; init; } = string.Empty;
    }
}
