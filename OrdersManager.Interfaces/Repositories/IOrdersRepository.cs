using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetAll(bool trackChanges, CancellationToken cancellationToken);
        Task<Order> GetById(Guid id, bool trackChanges, CancellationToken cancellationToken);
        Task<IEnumerable<Order>> GetByClientId(Guid clientId, CancellationToken cancellationToken);
        Task<Order> GetByScheduleId(Guid scheduleId, CancellationToken cancellationToken);
        Task Create(Order entity, CancellationToken cancellationToken);
        void Delete(Order entity);
        void Update(Order entity);
    }
}
