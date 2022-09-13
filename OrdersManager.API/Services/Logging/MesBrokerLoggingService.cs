using MassTransit;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Logging;
using SpaService.Domain.Messages.LogMessages;
using SpaService.Domain.Messages.Logs;

namespace OrdersManager.API.Services.Logging
{
    public class MesBrokerLoggingService : ILoggingService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public MesBrokerLoggingService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendLogMessage(Order order, OrderAction action)
        {
            LogMessageForCreation logMessage = new LogMessageForCreation();

            switch (action)
            {
                case OrderAction.Created:
                    logMessage.Title = $"Created order {order.Id}";
                    break;
                case OrderAction.Deleted:
                    logMessage.Title = $"Deleted order {order.Id}";
                    break;
            }

            logMessage.Details = $"Schedule Id: {order.ScheduleId}; Client Id: {order.ClientId}";
            logMessage.DateTime = DateTime.UtcNow;
            logMessage.Severity = "Info";

            await _publishEndpoint.Publish(logMessage);
        }
    }
}
