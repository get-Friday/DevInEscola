using Escola.Domain.DTO.V1;
using Escola.Domain.Exceptions;
using System.Net;

namespace Escola.Api.Config
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync (HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await TratamentoExcecao(httpContext, ex);
            }
        }
        private Task TratamentoExcecao(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;

            switch (exception)
            {
                case DuplicadoException:
                    status = HttpStatusCode.NotAcceptable;
                    message = exception.Message;
                    break;
                case InexistenteException:
                    status = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = "Ocorreu um erro interno. Contatar TI";
                    break;
            }

            ErrorDTO response = new(message);
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsJsonAsync(response);
        }
    }
}
