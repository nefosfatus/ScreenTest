using Company.Delivery.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;

namespace Company.Delivery.Api.Middlewares;

/// <summary>
/// ExceptionMiddleware
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// ExceptionMiddleware
    /// </summary>
    /// <param name="next"></param>
    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    /// <summary>
    ///InvokeAsync
    /// </summary>
    /// <param name="context"></param>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (EntityNotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Response.ContentType = "application/json";
            var result = "Not found";
            await context.Response.WriteAsync(result);
        }
    }
}
