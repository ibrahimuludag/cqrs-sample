using CqrsSample.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CqrsSample.Infrastructure.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
