using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DutchTreat
{
    public class Program
    {
        // A console app that listens to the web request
        // Can be started with IIS Express OR call the executable
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
