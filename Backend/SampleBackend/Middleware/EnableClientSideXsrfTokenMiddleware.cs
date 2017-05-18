using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace SampleBackend.Middleware
{
    /// <summary>
    /// Middleware to write an XSRF a secure antiforgery token to the response when the request path is
    /// not null and is not an api call.
    /// </summary>
    public class EnableClientSideXsrfTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAntiforgery _antiforgery;

        public EnableClientSideXsrfTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestPath = context.Request.Path.Value;

            if (requestPath != null && !requestPath.ToLower().Contains("/api"))
            {
                var tokens = _antiforgery.GetAndStoreTokens(context);
                context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions { HttpOnly = false, Secure = true });
            }

            await _next(context);
        }
    }
}
