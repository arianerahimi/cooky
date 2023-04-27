using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testweb.Areas.Identity.Data;
using testweb.Data;

[assembly: HostingStartup(typeof(testweb.Areas.Identity.IdentityHostingStartup))]
namespace testweb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<dbfinal1>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("dbtestwebConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                  .AddRoles<IdentityRole>()  .AddEntityFrameworkStores<dbfinal1>();

                services.AddAuthorization(x=>x.AddPolicy("AdminPolicy",p=>p.RequireRole("admin")));
            });
        }
    }
}
