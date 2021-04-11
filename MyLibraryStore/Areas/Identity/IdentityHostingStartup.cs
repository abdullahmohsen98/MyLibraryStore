using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyLibraryStore.Areas.Identity.Data;
using MyLibraryStore.Data;

[assembly: HostingStartup(typeof(MyLibraryStore.Areas.Identity.IdentityHostingStartup))]
namespace MyLibraryStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MyLibraryStoreContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MyLibraryStoreContextConnection")));

                services.AddDefaultIdentity<MyLibraryStoreUser>()
                    .AddEntityFrameworkStores<MyLibraryStoreContext>();
            });
        }
    }
}