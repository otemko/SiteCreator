using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DAL.ORM;
using DAL.ORM.Model;
using DAL.Interfaces;
using DAL.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SiteCreatorWeb
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

            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<IAchievementUserRepository, AchievementUserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILayoutRepository, LayoutRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<IStyleRepository, StyleRepository>();
            services.AddScoped<IStyleMenuRepository, StyleMenuRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagSiteRepository, TagSiteRepository>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SiteCreatorDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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

            app.UseFacebookAuthentication(new FacebookOptions()
            {
                AppId = Configuration["Authentication:Facebook:AppId"],
                AppSecret = Configuration["Authentication:Facebook:AppSecret"]
            });

            app.UseVkontakteAuthentication(new AspNetCore.Security.OAuth.Vkontakte.VkontakteAuthenticationOptions()
            {
                ClientId = Configuration["Authentication:Vkontakte:ClientId"],
                ClientSecret = Configuration["Authentication:Vkontakte:ClientSecret"]
            });

            app.UseTwitterAuthentication(new TwitterOptions()
            {
                ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"],
                ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"]
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
    }
}
