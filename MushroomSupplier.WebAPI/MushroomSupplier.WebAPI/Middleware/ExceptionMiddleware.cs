using System.Net;
using System.Text.Json;
using MushroomSupplier.Core.Exceptions;

namespace MushroomSupplier.WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        int statusCode;
        object response;

        switch (exception)
        {
            case NotFoundException notFoundEx:
                statusCode = (int)HttpStatusCode.NotFound;
                response = new { message = notFoundEx.Message };
                break;

            case ValidationException validationEx:
                statusCode = (int)HttpStatusCode.BadRequest;
                response = new { message = validationEx.Message, errors = validationEx.Errors };
                break;

            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                response = new { message = "Internal Server Error" };
                break;
        }

        context.Response.StatusCode = statusCode;
        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}