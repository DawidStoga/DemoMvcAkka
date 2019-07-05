using Microsoft.AspNetCore.Hosting;
using SelfHostedApi;
using System;

namespace SelfHosted_Api
{
    class Program
    {
        static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder()
                       .UseKestrel() //tiny web server. It can be replaced with any web server  
                       .UseStartup<Startup>()
                       .UseUrls("http://localhost:9876/")
                       .Build();

            hostBuilder.Run();

            Console.ReadKey();
        }
    }
}
