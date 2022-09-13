using OrdersManager.Domain.Models;
using SpaService.Domain.Messages.LogMessages;

namespace OrdersManager.Interfaces.Logging
{
    public interface ILoggingService
    {
        Task SendLogMessage(Order order, OrderAction action);
    }
}
