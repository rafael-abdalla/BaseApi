using System.Diagnostics;

namespace BaseApi.DTOs
{
    public class ErrorResponse
    {
        public ErrorResponse(HttpContext context)
        {
            Id = Activity.Current?.Id ?? context.TraceIdentifier;
            TraceIdentifier = context.TraceIdentifier;
            Mensagem = "Oops! Ocorreu algum problema, favor contatar ao suporte.";
            Data = DateTime.Now;
        }

        public ErrorResponse(HttpContext context, string mensagem)
        {
            Id = Activity.Current?.Id ?? context.TraceIdentifier;
            TraceIdentifier = context.TraceIdentifier;
            Mensagem = mensagem;
            Data = DateTime.Now;
        }

        public string Id { get; set; }
        public string TraceIdentifier { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
    }
}
