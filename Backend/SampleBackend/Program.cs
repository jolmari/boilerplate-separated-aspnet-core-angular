using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SampleBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup("SampleBackend") // The assembly from which the Startup[Environment] class is loaded.
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
