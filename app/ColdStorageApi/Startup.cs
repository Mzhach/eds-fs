using System;
using ColdStorageApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;

namespace ColdStorageApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<StorageContext>(opt =>
                opt.UseSqlite(_configuration.GetConnectionString("SqliteConnectionString")));

            var logger = new LoggerConfiguration()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200/"))
                {
                    IndexFormat = "eds-fs-index-{0:dd.MM.yyyy}",
                    MinimumLogEventLevel = LogEventLevel.Debug
                })
                .WriteTo.File("/data/logs.txt")
                .Enrich.WithProperty("Application", "ColdStorage")
                .CreateLogger();

            services.AddSingleton<ILogger>(logger);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages("text/plain", "Error. Status code : {0}");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
