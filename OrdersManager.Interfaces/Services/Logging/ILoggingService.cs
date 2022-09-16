using OrdersManager.Domain.Models;
using SpaService.Domain.Messages.LogMessages;

namespace OrdersManager.Interfaces.Logging
{
    public interface ILoggingService
    {
        Task SendCreatedMessage(Order order);
        Task SendUpdatedMessage(Order order);
        Task SendDeletedMessage(Order order);
    }
}
