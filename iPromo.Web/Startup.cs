using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using iPromo.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Amazon.SimpleSystemsManagement;
using Microsoft.AspNetCore.Http;

namespace iPromo.Web
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
            

            //add for SAML
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddAzureAd(options => Configuration.Bind("AzureAd", options))
            .AddCookie();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".iPromo.Session";
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });
            //SQL Connection String
            var cn = Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");//Get from config use in dev system. Config can't be check in to git
            
            if (string.IsNullOrEmpty(cn))
            {
                using (AmazonSimpleSystemsManagementClient ssm = new AmazonSimpleSystemsManagementClient(Amazon.RegionEndpoint.USEast1))
                {
                    Amazon.SimpleSystemsManagement.Model.GetParameterRequest request = new Amazon.SimpleSystemsManagement.Model.GetParameterRequest { Name = "mysqlconnectionstring", WithDecryption = true };
                    var responsetask = ssm.GetParameterAsync(request);
                    responsetask.GetAwaiter();
                    var response = responsetask.Result;
                    //if(responsetask.)
                    if (response != null)
                        cn = response.Parameter.Value;
                }
            }
            services.AddScoped<iPromoDataContext>(_ => new iPromoDataContext(cn));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            var sp = app.ApplicationServices;
        }
    }
}
