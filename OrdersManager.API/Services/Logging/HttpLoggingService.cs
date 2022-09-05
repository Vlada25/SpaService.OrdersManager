using OrdersManager.Domain.Models;
using OrdersManager.Domain.Models.Logging;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.API.Services.Logging
{
    public class HttpLoggingService : IHttpLoggingService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _loggingHost = "https://localhost:7113/api/Logs/Create";

        public HttpLoggingService()
        {
        }

        public void CreateLogMessage(Order order, OrderAction action)
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
            logMessage.DateTime = DateTime.Now;
            logMessage.Severity = "Info";

            _httpClient.PostAsJsonAsync(_loggingHost, logMessage);
        }
    }
}
