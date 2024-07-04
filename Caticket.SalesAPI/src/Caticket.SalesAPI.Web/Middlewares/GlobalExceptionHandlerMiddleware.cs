using System.Text;
using Caticket.SalesAPI.Core.Exceptions.Event;

namespace Caticket.SalesAPI.Web.Middlewares;

public class GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
{
    private RequestDelegate _next = next;
    private ILogger<GlobalExceptionHandlerMiddleware> _logger = logger;
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
        } catch (EventCapacityZeroException ex) {
            LogError(ex);

            await WriteMessage(httpContext, ex.Message, 400);
        } catch (EventDatePastException ex) {
            LogError(ex);

            await WriteMessage(httpContext, ex.Message, 400);
        } catch (EventNameRequiredException ex) {
            LogError(ex);

            await WriteMessage(httpContext, ex.Message, 400);
        } catch (Exception ex) {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}