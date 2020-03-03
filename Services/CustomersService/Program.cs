using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CustomersService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(opts => opts.ValidateScopes = false)
                .UseUrls("http://*:5001")
                .UseStartup<Startup>();
    }
}
