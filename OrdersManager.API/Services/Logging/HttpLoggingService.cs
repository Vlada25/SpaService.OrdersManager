using OrdersManager.Domain.Models;
using OrdersManager.Domain.Models.Logging;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.API.Services.Logging
{
    public class HttpLoggingService : ILoggingService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _loggingHost;

        public HttpLoggingService(string host)
        {
            _loggingHost = host + "/Logs/Create";
        }

        public void SendLogMessage(Order order, OrderAction action)
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

            _httpClient.PostAsJsonAsync(_loggingHost, logMessage);
        }
    }
}
