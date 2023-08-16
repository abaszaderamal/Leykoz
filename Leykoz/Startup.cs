using System;
using FluentValidation.AspNetCore;
using Leykoz.Business.Service.Implementations;
using Leykoz.Business.Service.Interfaces;
using Leykoz.Business.Validators.Salior;
using Leykoz.Core.Abstract;
using Leykoz.Core.Entities;
using Leykoz.Data.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Leykoz.Data.DAL;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.EntityFrameworkCore;

namespace Leykoz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //maile config ler adminden

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddControllersWithViews()
                //.AddSessionStateTempDataProvider()
                .AddFluentValidation(p =>
                    p.RegisterValidatorsFromAssemblyContaining<SaliorVMValidator>()); //diff asembly
            // services.Configure<KestrelServerOptions>(
            //     Configuration.GetSection("Kestrel"));
            services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));
            services.AddDbContext<AppDbContext>(options =>
            {
           //     options.UseSqlServer(Configuration.GetConnectionString("Default"));
                options.UseNpgsql(Configuration.GetConnectionString("Default"));

            });
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false; //@ * gibi karakterler olmalı

                options.Lockout.MaxFailedAccessAttempts = 15; //5 girişten sonra kilitlenioyr. 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(5); //5 dk sonra açılır
                options.Lockout.AllowedForNewUsers = true; //üsttekilerle alakalı

                //options.User.AllowedUserNameCharacters = ""; //olmasını istediğiniz kesin karaterrleri yaz

                options.User.RequireUniqueEmail = true; //unique emaail adresleri olsun her kullanıcının 

                options.SignIn.RequireConfirmedEmail = false; //Kayıt olduktan email ile token gönderecek 
                options.SignIn.RequireConfirmedPhoneNumber = false; //telefon doğrulaması
            });

            // services.Configure<IdentityOptions>(Options =>
            // {
            //     Options.Password.RequiredLength = 8;
            //     Options.Password.RequireNonAlphanumeric = false;
            //     Options.Password.RequireLowercase = false;
            //     Options.Password.RequireUppercase = false;
            //     Options.Password.RequireDigit = false;
            // });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
            // services.AddScoped<ISlideService, SlideService>();
            // services.AddScoped<ISiteSettingService, SiteSettingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Production
            // Development
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("MyAllowSpecificOrigins");
            app.UseAuthentication();
            app.UseAuthorization();
            // app.Run(async (context) =>
            // {
            //     context.Features.Get<IHttpMaxRequestBodySizeFeature>()
            //         .MaxRequestBodySize = 10 * 1024;
            //
            //     var minRequestRateFeature =
            //         context.Features.Get<IHttpMinRequestBodyDataRateFeature>();
            //     var minResponseRateFeature =
            //         context.Features.Get<IHttpMinResponseDataRateFeature>();
            //
            //     if (minRequestRateFeature != null)
            //     {
            //         minRequestRateFeature.MinDataRate = new MinDataRate(
            //             bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
            //     }
            //
            //     if (minResponseRateFeature != null)
            //     {
            //         minResponseRateFeature.MinDataRate = new MinDataRate(
            //             bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
            //     }
            // });
            // app.UseHttpsRedirection();
            // app.UseStaticFiles();
            // app.UseSession();
            // app.UseRouting();
            // app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}