using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Tesco.Helper;
using Tesco.Model;

namespace Tesco.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddCors();
            string filePathToIoC = AppDomain.CurrentDomain.BaseDirectory;
            services.AddSingleton(new BasePath { BaseDirectory = filePathToIoC });
            List<Dictionary<string, string>> configDis = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(File.ReadAllText(filePathToIoC + "\\IOC.json"));

            foreach (Dictionary<string, string> entry in configDis)
            {
                Type interfaceType = Type.GetType(entry[Constants.INTERFACE]);
                Type implementationType = Type.GetType(entry[Constants.IMPLEMENTATION]);

                services.AddScoped(interfaceType, implementationType);
            }
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddControllersWithViews();
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
