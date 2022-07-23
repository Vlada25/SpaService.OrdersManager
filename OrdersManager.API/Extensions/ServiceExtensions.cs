using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Interfaces;

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

        public static void ConfigureDbManagers(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
