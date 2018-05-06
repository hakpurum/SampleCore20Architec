using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SampleCoreArch.Admin.Filters;
using SampleCoreArch.Business;
using SampleCoreArch.Core.Logging;
using System;

namespace SampleCoreArch.Admin
{
    public class Startup
    {
        private IServiceProvider _serviceProvider;



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(
                config =>
                {
                    config.Filters.Add(new KoBindFilterAttribute());
                }).AddXmlFormaterExtensions();

            //services.AddMvc().AddXmlFormaterExtensions();
            services.AddDataLayerServices();
            services.AddBusinessServices();

            _serviceProvider = services.BuildServiceProvider();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new CustomLoggerProvider(_serviceProvider));
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
