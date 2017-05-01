using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RadniNalog.Data;
using RadniNalog.Models;
using RadniNalog.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using RazorPDFCore;

namespace RadniNalog
{
    public class Startup
    {
        

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public  void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options=> {
                options.Cookies.ApplicationCookie.LoginPath = new PathString("/Account/Login");
                options.Cookies.ApplicationCookie.AccessDeniedPath = new PathString("/Account/Authorization");
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                
                .AddDefaultTokenProviders();

            services.AddMvc();
            //    .AddJsonOptions(
            //options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore ); ;

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IFillRole, FillRole>();

            services.AddSingleton<PdfResultExecutor>();
           

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,IFillRole fillRole)
        {


            //app.UseCookieAuthentication(new CookieAuthenticationOptions()
            //{

            //    LoginPath = new PathString("/Account/Login/"),
            //    AccessDeniedPath = new PathString("/Home/Index")

            //});


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

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            fillRole.createRolesandUsers();


        }

        // In this method we will create default User roles and Admin user for login   

    }
}
