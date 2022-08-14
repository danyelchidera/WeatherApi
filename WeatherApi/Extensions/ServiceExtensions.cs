using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

namespace WeatherApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config) =>
            services.AddDbContext<RepositoryContext>(opt => opt.UseSqlServer(config.GetConnectionString("sqlConnection")));

        public static void ConfigureHttpService(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpService, HttpService>();
            services.AddScoped<IHttpService, HttpService>();
        }
            

    }
}
