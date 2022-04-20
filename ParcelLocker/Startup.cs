using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParcelLocker.Models;
using ParcelLocker.Models.Entities;
using ParcelLocker.Models.IRepositories;
using ParcelLocker.Models.IServices;
using ParcelLocker.Models.Repositories;
using ParcelLocker.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelLocker
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
            services.AddScoped<IReasonRepository, ReasonRepository>();
            services.AddScoped<IComplaintRepository, ComplaintRepository>();
            services.AddScoped<ILockerRepository, LockerRepository>();
            services.AddScoped<IParcelRepository, ParcelRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILockerService, LockerService>();
            services.AddScoped<IParcelService, ParcelService>();
            services.AddScoped<IComplaintService, ComplaintService>();
            services.AddScoped<IReasonService, ReasonService>();
            services.AddScoped<ICourierService, CourierService>();
            services.AddScoped<IComplaintReasonRepository, ComplaintReasonRepository>();
            services.AddScoped<IComplaintReasonService, ComplaintReasonService>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactService>();

           // services.AddDbContext<ParcelLockerContext>(options => options.UseMySQL(Configuration.GetConnectionString("ParcelLockerCS")));
            services.AddDbContext<ParcelLockerContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ParcelLockerCS")));
            services.AddControllersWithViews();
            services.AddIdentity<Courier, IdentityRole>()
                .AddEntityFrameworkStores<ParcelLockerContext>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.ConfigureApplicationCookie(o =>
            {
                o.LoginPath = new PathString("/Courier/Index");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=GetParcel}/{id?}");
            });
        }
    }
}
