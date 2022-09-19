using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetAll(bool trackChanges);
        Task<Order> GetById(Guid id, bool trackChanges);
        Task<IEnumerable<Order>> GetByClientId(Guid clientId);
        Task Create(Order entity);
        void Delete(Order entity);
        void Update(Order entity);
    }
}
