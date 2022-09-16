using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrdersManager.API.Services;
using OrdersManager.API.Services.Logging;
using OrdersManager.Database;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;
using OrdersManager.Interfaces.Services;
using OrdersManager.Messaging.Consumers;
using SpaService.Domain.Configuration;

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

            services.AddScoped<ILoggingService, MesBrokerLoggingService>();
        }

        public static void ConfigureConstants(this IServiceCollection services,
            IConfiguration configuration)
        {
            string host = configuration.GetValue<string>("Host");

            services.AddSingleton(host);
        }

        public static void ConfigureMessageBroker(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<ClientDeletedConsumer>();
                x.AddConsumer<ClientUpdatedConsumer>();
                x.AddConsumer<MasterUpdatedConsumer>();
                x.AddConsumer<MasterDeletedConsumer>();
                x.AddConsumer<ServiceDeletedConsumer>();
                x.AddConsumer<ServiceUpdatedConsumer>();

                MessageBrokerExtensions.ConfigureRabbitMq(configuration, x);
            });
        }
    }
}
