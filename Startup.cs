using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DutchTreat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // Set up the dependency services that can be found in the system
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Limite the exception page to developers only
            // Check the Solution Property => Debug => Environment variable
            // If absent, it assumes it's in production.
            // Equivalent to env.IsEnvironment("Development ")
            if (env.IsDevelopment())
            {
                // Exception page can be shown to developers
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // TODO: add error page
            }

            // The order of the middleware matters
            // Middleware = pipelines

            // Points the default folder to wwwroot
            // app.UseDefaultFiles();

            app.UseStaticFiles();

            // Front-end package management needs a nuget package
            app.UseNodeModules();

            // Generic routing inside of ASP dotnet core
            app.UseRouting();
            
            // For MVC routing decisions
            app.UseEndpoints(configure =>
            {
                // How to find a specific controller using these semantics 
                // Name the route
                // Look for controller name that matches the names inside our controllers
                // Look for action call in the controller with matched names
                configure.MapControllerRoute("Fallback", "{controller}/{action}/{id?}",
                    // If none of them matched, use the default below
                    new { controller = "App", action ="Index" });
            });

        }
    }
}
