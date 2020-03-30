using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartHome.Controller;
using SmartHome.Controller.Controllers;
using SmartHome.Data.Store;
using SmartHome.Data.Store.Factories;
using SmartHome.WebApp.Hubs;
using SmartHome.WebApp.Services;

namespace SmartHome.WebApp
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _webHostEnvironment = environment;
            _configuration = configuration;
        }
        
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddSignalR();
            services.AddHostedService<DeviceControllerBackgroundService>();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });


            services.AddSingleton<IStoreFactory>(new EFStoreFactory(_configuration.GetConnectionString("MyConnection")));
            services.AddSingleton<IDeviceController, DeviceController>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ActionDeviceHub>("/hub/device/bool");
                endpoints.MapHub<EventActionDeviceHub>("/hub/event-device/bool");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
