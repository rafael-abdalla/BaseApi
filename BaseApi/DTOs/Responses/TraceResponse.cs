using System.Diagnostics;

namespace BaseApi.DTOs
{
    public class TraceResponse
    {
        public TraceResponse(HttpContext context, Exception exception)
        {
            Id = Activity.Current?.Id ?? context.TraceIdentifier;
            TraceIdentifier = context.TraceIdentifier;
            StackTrace = exception.StackTrace;
            RequestPath = context.Request.Path.Value;
            ErrorMessage = exception.Message;
            InnerException = exception.InnerException?.Message;
        }

        public string Id { get; set; }
        public string TraceIdentifier { get; set; }
        public string? StackTrace { get; set; }
        public string? RequestPath { get; set; }
        public string ErrorMessage { get; set; }
        public string? InnerException { get; set; }
    }
}
