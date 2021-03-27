using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVC.Data;
using MVC.Models;
using System;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();

        }


        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
      {
          webBuilder.UseStartup<Startup>();
      });
      //.ConfigureLogging(logging =>
      //{
      //    // clear default logging providers
      //    logging.ClearProviders();

      //    // add built-in providers manually, as needed 
      //    logging.AddConsole();
      //    logging.AddDebug();
      //    logging.AddEventLog();
      //    logging.AddEventSourceLogger();
      //});
    }
}