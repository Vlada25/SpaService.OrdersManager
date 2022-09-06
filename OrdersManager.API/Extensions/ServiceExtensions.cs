using Microsoft.EntityFrameworkCore;
using OrdersManager.API.Services;
using OrdersManager.API.Services.Logging;
using OrdersManager.Database;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;
using OrdersManager.Interfaces.Services;

namespace OrdersManager.API.Extensions
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

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OrdersManagerDbContext>(opts =>
                opts.UseNpgsql(configuration.GetConnectionString("sqlConnection"), b =>
                    b.MigrationsAssembly("OrdersManager.Database")));
        }

        public static void ConfigureDbServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddScoped<IFeedbacksService, FeedbacksService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<ISchedulesService, SchedulesService>();

            services.AddSingleton<ILoggingService, HttpLoggingService>();
        }

        public static void ConfigureConstants(this IServiceCollection services,
            IConfiguration configuration)
        {
            string host = configuration.GetValue<string>("Host");

            services.AddSingleton(host);
        } 
    }
}
