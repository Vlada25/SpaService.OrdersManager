using MassTransit;
using OrdersManager.Domain.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Logging;
using SpaService.Domain.Messages.LogMessages;
using SpaService.Domain.Messages.Logs;

namespace OrdersManager.API.Services.Logging
{
    public class MessageBrokerLoggingService : ILoggingService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MessageBrokerLoggingService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendCreatedMessage(Order order)
        {
            LogMessageForCreation logMessage = new LogMessageForCreation
            {
                Title = $"Created order {order.Id}",
                Details = $"Schedule Id: {order.ScheduleId}; " +
                    $"Client Id: {order.ClientId}; " +
                    $"Status: {EnumExtensions.GetDisplayName(order.Status)}",
                DateTime = DateTime.UtcNow,
                Severity = "Info"
            };

            await _publishEndpoint.Publish(logMessage);
        }

        public async Task SendDeletedMessage(Order order)
        {
            LogMessageForCreation logMessage = new LogMessageForCreation
            {
                Title = $"Deleted order {order.Id}",
                Details = $"Schedule Id: {order.ScheduleId}; " +
                    $"Client Id: {order.ClientId}; " +
                    $"Status: {EnumExtensions.GetDisplayName(order.Status)}",
                DateTime = DateTime.UtcNow,
                Severity = "Info"
            };

            await _publishEndpoint.Publish(logMessage);
        }

        public async Task SendUpdatedMessage(Order order)
        {
            LogMessageForCreation logMessage = new LogMessageForCreation
            {
                Title = $"Updated order {order.Id}",
                Details = $"Schedule Id: {order.ScheduleId}; " +
                    $"Client Id: {order.ClientId}; " +
                    $"Status: {EnumExtensions.GetDisplayName(order.Status)}",
                DateTime = DateTime.UtcNow,
                Severity = "Info"
            };

            await _publishEndpoint.Publish(logMessage);
        }
    }
}
