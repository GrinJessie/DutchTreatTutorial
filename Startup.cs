using DutchTreat.Services;
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
            services.AddRazorPages();

            // Don't have any data on themselves, often just methods that do things
            // Dependency injection layer to figure out how to construct one of NullMailService
            // Centralize the service instead of put the instance every where across app
            // Do all the heavy lifting here for the rest of the app
            services.AddTransient<IMailService, NullMailService>();

            // Add services that are a little bit more expensive to create, but keep around the length of the connection
            // The default scope is the length of the request from the client 
            // services.AddScoped();

            // Services expensive to build, created once and kept for the lifetime of the server being up
            // services.AddSingleton();
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
                // Not a view that returned by controller
                // This is a page (razor page)
                // Need to add the razor page to the services on start up
                app.UseExceptionHandler("/Error");
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
                configure.MapRazorPages();
            });

        }
    }
}
