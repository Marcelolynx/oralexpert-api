using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Serilog;

namespace Eleven.OralExpert.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // Passa a requisição para o próximo middleware
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex); // Lida com exceções
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        
        Log.Error(exception, "Um erro não tratado ocorreu.");

       
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

         
        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.",
#if DEBUG
            Details = exception.Message // Somente em desenvolvimento
#else
                Details = "Detalhes disponíveis apenas em ambiente de desenvolvimento."
#endif
        };

         
       await context.Response.WriteAsync(JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  
            WriteIndented = true  
        }));
    }
}