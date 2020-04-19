using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Evento.Service
{
    public static class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        /// <param name="args">Command line or service arguments</param>
        public static void Main(string[] args)
        {
            using (var host = BuildWebHost(args))
            {

                host.Run();

            }
        }

        /// <summary>
        /// Check whether run as service.
        /// </summary>
        /// <param name="args">The arguments for checking.</param>
        /// <returns>True indicates in service mode.</returns>
        private static bool IsServiceMode(string[] args)
        {
            if (System.Diagnostics.Debugger.IsAttached || (args != null && args.Contains("--console")))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Build web host.
        /// </summary>
        /// <returns>web host.</returns>
        private static IWebHost BuildWebHost(string[] args)
        {           
            var baseRoot = Directory.GetCurrentDirectory();
            if (IsServiceMode(args))
            {
                var exePath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                baseRoot = Path.GetDirectoryName(exePath);
            }

            Console.WriteLine(baseRoot);

            var config = new ConfigurationBuilder()
            .SetBasePath(baseRoot)
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

            var url = config["ASPNETCORE_URLS"] ?? "http://*:5000";
            var env = config["ASPNETCORE_ENVIRONMENT"] ?? "Development";

            var webHostBuilder = new WebHostBuilder()
                .UseKestrel()
                .UseUrls(url)
                .UseEnvironment(env)
                .UseContentRoot(baseRoot)
                .UseConfiguration(config);


            return webHostBuilder.UseStartup<Startup>().Build();
        }
    }
}
