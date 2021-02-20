using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApps
{
    public class StartUp
    {
        public void ConfigurationServices(IServiceCollection servise)
        {

        }
        public void Configure(IApplicationBuilder app,IWebHostEnvironment env )
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello");
                });
            });
        }
    }
}
