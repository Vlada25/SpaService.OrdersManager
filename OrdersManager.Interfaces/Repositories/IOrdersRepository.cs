using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetAll(bool trackChanges);
        Order GetById(Guid id, bool trackChanges);
        Order GetByClientId(Guid clientId);
        void Create(Order entity);
        void Delete(Order entity);
    }
}
