using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WeCommerce.Areas.Identity.IdentityHostingStartup))]
namespace WeCommerce.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}