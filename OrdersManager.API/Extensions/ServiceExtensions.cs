using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrdersManager.API.Services.Logging;
using OrdersManager.API.Validators;
using OrdersManager.Database;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;
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

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public static void ConfigureDbServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ScheduleForCreationValidator>();

            services.AddScoped<ILoggingService, MessageBrokerLoggingService>();
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
            services.ConfigureMessageBroker(configuration, consumersConfig =>
            {
                consumersConfig.AddConsumer<ClientDeletedConsumer>();
                consumersConfig.AddConsumer<ClientUpdatedConsumer>();
                consumersConfig.AddConsumer<MasterDeletedConsumer>();
                consumersConfig.AddConsumer<MasterUpdatedConsumer>();
                consumersConfig.AddConsumer<ServiceDeletedConsumer>();
                consumersConfig.AddConsumer<ServiceUpdatedConsumer>();
                consumersConfig.AddConsumer<AddressUpdatedConsumer>();
                consumersConfig.AddConsumer<ServiceTypeUpdatedConsumer>();
            });
        }
    }
}
