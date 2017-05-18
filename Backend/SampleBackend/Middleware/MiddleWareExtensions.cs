using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;

namespace SampleBackend.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseEnableClientSideRoutingMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<EnableClientSideRoutingMiddleWare>();
        }

        public static IApplicationBuilder UseEnableClientSideXsrfTokenMiddleware(this IApplicationBuilder builder, IAntiforgery antiforgery)
        {
            return builder.UseMiddleware<EnableClientSideXsrfTokenMiddleware>(antiforgery);
        }
    }
}
