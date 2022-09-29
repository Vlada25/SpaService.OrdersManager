using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Interfaces.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<IEnumerable<Order>> GetByClientId(Guid clientId);
        Task<Order> Create(OrderForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteByClientId(Guid clientId);
        Task<bool> Update(Guid id, OrderForUpdateDto entityForUpdate);
        Task<bool> UpdateOrders(IEnumerable<Order> entities);
        Task<bool> UpdateClient(ClientUpdated client);
    }
}
