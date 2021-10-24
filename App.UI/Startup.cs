using App.Core.Domain;
using App.Core.Managers;
using App.Core.Models;
using App.Core.Repositories;
using App.UI.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace App.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<Protein4allContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("AppCore")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true; options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                
                .AddEntityFrameworkStores<Protein4allContext>().AddDefaultUI().AddDefaultTokenProviders();


                       services.AddRazorPages();
           
            services.AddScoped<CategoryManager>();
            services.AddScoped<ProductManager>();
            
            services.AddCustomizedRoutes();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
