using System.Text;
using Caticket.PartnerAPI.Domain.Exceptions;

namespace Caticket.PartnerAPI.Web2.Middlewares;

public class GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger) {
    private readonly RequestDelegate _next = next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger = logger;

    private void LogError(Exception exception) {
        _logger.LogError(exception, exception.Message);
    }

    private async Task WriteMessage(HttpContext httpContext, string message, int? statusCode = null) {
        if(statusCode != null) {
            httpContext.Response.StatusCode = (int)statusCode;
        }
        
        var bytes = Encoding.UTF8.GetBytes(message);
        await httpContext.Response.Body.WriteAsync(bytes);
    }

    public async Task InvokeAsync(HttpContext httpContext) {
        try {
            await _next(httpContext);
        } catch(BadHttpRequestException badRequestException) {
            LogError(badRequestException);
            await WriteMessage(
                httpContext, 
                "Failed to read parameters from the request body as JSON. Some property does not correspond to its actual type.", 
                400
            );
        } catch(FormatException formatException) {
            LogError(formatException);
            await WriteMessage(
                httpContext, 
                formatException.Message, 
                422
            );
        } catch(IdNotFoundException idNotFoundException) {
            LogError(idNotFoundException);
            await WriteMessage(
                httpContext, 
                idNotFoundException.Message, 
                404
            );
        }
    }
}