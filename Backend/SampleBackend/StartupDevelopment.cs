using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleBackend.Middleware;

namespace SampleBackend
{
    public class StartupDevelopment
    {
        private IConfigurationRoot Configuration { get; }

        public StartupDevelopment(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add Anti-Forgery token support with Angular-supported header name.
            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            
            // Add framework services.
            // Force HTTPS-only for all requests.
            services.AddMvc(options => options.Filters.Add(new RequireHttpsAttribute()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IAntiforgery antiforgery)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Forced HTTPS with URL-rewriting.
            app.UseRewriter(new RewriteOptions().AddRedirectToHttps(302, 44300));

            // Enable client-side routing and add XSRF-cookie to response.
            app.UseEnableClientSideRoutingMiddleWare();
            app.UseEnableClientSideXsrfTokenMiddleware(antiforgery);

            // Configure use of default static files from wwwroot. Leave MVC only for API-controller routing.
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}