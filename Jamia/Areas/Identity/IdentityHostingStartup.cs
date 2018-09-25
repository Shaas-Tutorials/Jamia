using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Jamia.Areas.Identity.IdentityHostingStartup))]
namespace Jamia.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}