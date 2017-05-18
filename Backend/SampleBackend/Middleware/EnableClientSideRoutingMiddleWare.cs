using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SampleBackend.Middleware
{
    /// <summary>
    /// Middleware to catch 404 errors given when trying to navigate to server-side routing
    /// paths that have no file extensions (html/css/js).
    /// Rewrites the request path in such a case to point to root.
    /// </summary>
    public class EnableClientSideRoutingMiddleWare
    {
        private readonly RequestDelegate _next;

        public EnableClientSideRoutingMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == StatusCodes.Status404NotFound &&
                !Path.HasExtension(context.Request.Path.Value))
            {
                context.Request.Path = "/";
                await _next(context);
            }
        }
    }
}
