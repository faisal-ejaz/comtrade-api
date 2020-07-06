using System;
using Comtrade.Api.Core.Constants;
using Comtrade.Api.Core.DTO;
using Comtrade.Api.Core.Interfaces;
using Comtrade.Api.Service.DataServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Comtrade.Api
{
    public class Startup
    {
        #region .Net Core boilerplate
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            AddAppSettings(services);

            AddHTTPClient(services);

            AddDependancies(services);

            services.AddControllers().AddJsonOptions(options =>
            {
                // Use the default property (Pascal) casing.
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Only allow any origin for development environment
                app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action}");
            });
          
        }
        #endregion

        #region Service Configurations
        private void AddDependancies(IServiceCollection services) 
        {
            services.AddScoped<IComtradeDataService, ComtradeDataService>();
        }
        private void AddHTTPClient(IServiceCollection services)
        {
            string basePath = Configuration.GetSection("ComtradeAppSettings").Get<ComtradeAppSettings>().BasePath;

            services.AddHttpClient(AppSettingConstants.ComtradeClientName, client =>
            {
                client.BaseAddress = new Uri(basePath);
            });
        }
        private void AddAppSettings(IServiceCollection services)
        {
            services.Configure<ComtradeAppSettings>(Configuration.GetSection("ComtradeAppSettings"));
        }
        #endregion

    }
}
