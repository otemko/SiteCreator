using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SiteCreator.ORM;
using SiteCreator.Entities;
using SiteCreator.BLL.Services;
using SiteCreator.DAL;
using SiteCreator.BLL.IService;
using System.Collections.Generic;

namespace SiteCreator.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
                builder.AddJsonFile("userSecrets.json", optional: true, reloadOnChange: true);
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<SiteCreatorDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            AddDependencies(services);

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SiteCreatorDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });

            services.AddTransient<SeedData>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            SeedData seeder)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseApplicationInsightsExceptionTelemetry();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseIdentity();

            seeder.Seed();

            UseFacebookAuthentication(app);

            app.UseVkontakteAuthentication(new AspNetCore.Security.OAuth.Vkontakte.VkontakteAuthenticationOptions()
            {
                ClientId = Configuration["Authentication:Vkontakte:ClientId"],
                ClientSecret = Configuration["Authentication:Vkontakte:ClientSecret"]
            });
            UseTwitterAuthentication(app);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }

        private void UseTwitterAuthentication(IApplicationBuilder app)
        {
            var options = new TwitterOptions()
            {
                ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"],
                ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"],
                RetrieveUserDetails = true,
            };


            app.UseTwitterAuthentication(options);
        }

        private void UseFacebookAuthentication(IApplicationBuilder app)
        {
            var options = new FacebookOptions()
            {
                AppId = Configuration["Authentication:Facebook:AppId"],
                AppSecret = Configuration["Authentication:Facebook:AppSecret"],
            };

            options.Scope.Add("id");

            app.UseFacebookAuthentication(options);
        }

        private void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEntityRepository, EntityRepository>();
        }
    }
}
