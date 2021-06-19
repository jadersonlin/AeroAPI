using System;
using System.IO;
using System.Reflection;
using AeroAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AeroAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(GetXmlCommentsFilePath());
            });

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("MyConnection"));
            });

            services.AddScoped<IRepository<Passageiro>, Repository<Passageiro>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AeroAPI V1");
                c.RoutePrefix = string.Empty;
            });

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

        private static string GetXmlCommentsFilePath()
        {
            var basePath = AppContext.BaseDirectory;
            var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            return Path.Combine(basePath, fileName);
        }
    }
}
