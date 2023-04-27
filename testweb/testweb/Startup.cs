
using Microsoft.AspNetCore.HttpsPolicy;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SharePoint.Client;
using testweb.Areas.Identity.Data;




using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace testweb
{
    public class Startup
    {
        private string[] args;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddSession();
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)

        {



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
          

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            InitIdentity(userManager, roleManager).Wait();
        }

        private async Task InitIdentity(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser admin=await userManager.FindByNameAsync("admin@gmail.com");
            if(admin==null)
            {
                admin = new ApplicationUser
                {
                   firstName="admin",
                   lastName="ari",
                   UserName="admin@gmail.com",
                   Email="admin@gmail.com",
                   EmailConfirmed=true
                };
                await userManager.CreateAsync(admin,"Pp=-0987");
                if(await roleManager.RoleExistsAsync("admin")==false)
                {
                    await roleManager.CreateAsync(new IdentityRole("admin"));
                }
                if(await roleManager.RoleExistsAsync("seller")==false)
                {
                    await roleManager.CreateAsync(new IdentityRole("seller"));
                }
                if(await roleManager.RoleExistsAsync("customer")==false)
                {
                    await roleManager.CreateAsync(new IdentityRole("customer"));
                }
                if(await userManager.IsInRoleAsync(admin, "admin")==false)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
                if (await userManager.IsInRoleAsync(admin, "seller") == false)
                {
                    await userManager.AddToRoleAsync(admin, "seller");
                }
                if(await userManager.IsInRoleAsync(admin,"customer")==false)
                {
                    await userManager.AddToRoleAsync(admin, "seller");

                }
            }
        }


    }
}
