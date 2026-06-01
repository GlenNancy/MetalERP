using FluentValidation;
using System.Text.Json;

namespace MetalERP.Api.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(
        RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;

            context.Response.ContentType =
                "application/json";

            var response = new
            {
                message = "Validation failed",
                errors = ex.Errors
                    .Select(x => x.ErrorMessage)
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;

            context.Response.ContentType =
                "application/json";

            var response = new
            {
                message = "Internal server error"
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
    }
}