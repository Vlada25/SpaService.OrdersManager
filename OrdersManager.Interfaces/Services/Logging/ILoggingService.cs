using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Logging
{
    public interface ILoggingService
    {
        Task SendCreatedMessage(Order order);
        Task SendUpdatedMessage(Order order);
        Task SendDeletedMessage(Order order);
    }
}
