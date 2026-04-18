using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApiShop.middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ErrorMiddleware(RequestDelegate next , ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                httpContext.Response.StatusCode = 500;
                _logger.LogError(e + "call stack" + e.StackTrace);
            }

            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseerrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorMiddleware>();
        }
    }
}
