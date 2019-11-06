using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace saraproject
{
    public class Program
    {
        public static async Task Main(string[] args) 
        {
            var host =  CreateHostBuilder(args).Build();
            
            //Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<MainInfoContext>();
                    await MainInfoContextSeed.SeedAsync(context);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //Continue to run the application
            host.Run();
            
        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(
                    webBuilder => webBuilder.UseStartup<Startup>());
    }
}