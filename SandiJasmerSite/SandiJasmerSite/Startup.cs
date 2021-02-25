using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TheRockFanPage.Models;
using TheRockFanPage.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;

namespace TheRockFanPage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container..
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // inject our repositories into our controllers
            services.AddTransient<IStoriesRepo, StoriesRepo>(); // Repository Interface, Repository Class in the generics
                
            //context -> DB provider -> into our connection string
            services.AddDbContext<StoriesContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ConnectionString"]));

            //Adding Identity 
            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<StoriesContext>().AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StoriesContext context)
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

            //This method get called by the runtime, use this methog to configure the HTTP request pipeline. 
            
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame_Options", "SAMEORIGIN");
                context.Response.Headers.Add("Paragma", "no-cache");
                context.Response.Headers.Add("Cache-Control", "no-chche");
                await next();
            });
            

            //Lab #6 error 
            app.UseCookiePolicy(new CookiePolicyOptions { HttpOnly = HttpOnlyPolicy.Always, Secure = CookieSecurePolicy.Always });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            //Identity and Security starting
            app.UseAuthorization();          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var serviceProvider = app.ApplicationServices;
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            SeedData.Seed(context, userManager, roleManager);
        }
    }
}
