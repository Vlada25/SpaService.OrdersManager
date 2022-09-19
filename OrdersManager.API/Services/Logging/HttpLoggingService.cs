using Microsoft.OpenApi.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Logging;
using SpaService.Domain.Messages.Logs;

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

            await _httpClient.PostAsJsonAsync(_loggingHost, logMessage);
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

            await _httpClient.PostAsJsonAsync(_loggingHost, logMessage);
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

            await _httpClient.PostAsJsonAsync(_loggingHost, logMessage);
        }
    }
}
