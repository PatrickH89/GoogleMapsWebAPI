using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using GoogleMapsWebAPI.Models.Configuration;
using GoogleMapsWebApi.Models.Configuration;
using GoogleMapsWebAPI.Interfaces;
using GoogleMapsApi.Services;
using GoogleMapsWebAPI.Mapper;

namespace GoogleMapsWebAPI
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
            services.AddControllers();
            services.AddMvc();

            EFConfiguration efConfig = new EFConfiguration();
            Configuration.Bind("EFConfig", efConfig);
            services.AddSingleton(efConfig);

            var config = new GoogleConfiguration();
            Configuration.Bind("GoogleMaps", config);
            services.AddSingleton(config);

            services.AddHttpClient<IGoogleLocationService, GoogleLocationService>();
            services.AddTransient<IAddressDatabaseService, AddressDatabaseService>();
            services.AddTransient<IAddressMapper, AddressMapper>();
            services.AddDbContext<AddressContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
