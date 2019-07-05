using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SelfHostedApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = new WebHostBuilder()
                       .UseKestrel() //tiny web server. It can be replaced with any web server  
                       .UseStartup<Startup>()
                       .Build();

            hostBuilder.Run();

            Console.ReadKey();
        }

    }
}
