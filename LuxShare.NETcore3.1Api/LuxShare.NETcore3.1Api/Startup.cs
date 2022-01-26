using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LuxShare.NETcore3._1Api
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
            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("WeatherForecast", new Microsoft.OpenApi.Models.OpenApiInfo {
                    Title="²âÊÔApi",
                    Version="°æ±¾",
                    Description="ÃèÊö",
                    Contact= new Microsoft.OpenApi.Models.OpenApiContact { 
                        Name="×÷Õß",
                        Email="ÓÊÏä"
                    }
                });

                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmlPath = Path.Combine(basePath, "LuxShare.NETcore3.1Api.xml");
                c.IncludeXmlComments(xmlPath);
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            //ÅäÖÃ¿çÓò
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            // ÆôÓÃSwaggerÖÐ¼ä¼þ
            app.UseSwagger();

            // ÅäÖÃSwaggerUI
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/WeatherForecast/swagger.json", "WeatherForecast");
                //c.SwaggerEndpoint("/swagger/Tapworks/swagger.json", "Tapworks");
                //c.SwaggerEndpoint("/swagger/Asm/swagger.json", "Asm");
                c.RoutePrefix = string.Empty;
            });

  
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseEndpoints(x => x.MapControllers());
        }
    }
}
