using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace InventoryApp.API.Middleware;

/// <summary>
/// Provides a centralized mechanism for handling unhandled exceptions across the application,
/// including validation errors, and returning standardized error responses.
/// </summary>
public static class ExceptionHandlingMiddleware
{
    /// <summary>
    /// Configures a global exception handler that catches exceptions and returns
    /// consistent JSON error responses, including validation errors.
    /// </summary>
    /// <param name="app">The application builder used to configure middleware.</param>
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(config =>
        {
            config.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                switch (exception)
                {
                    case ValidationException validationEx:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;

                        var errors = validationEx.Errors
                            .Select(e => new { field = e.PropertyName, error = e.ErrorMessage });

                        await context.Response.WriteAsJsonAsync(new { errors });
                        break;

                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsJsonAsync(new { error = exception?.Message });
                        break;
                }
            });
        });
    }
}
