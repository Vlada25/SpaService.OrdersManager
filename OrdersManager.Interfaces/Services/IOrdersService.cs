using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Interfaces.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order> Create(OrderForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteByClientId(Guid clientId);
        Task<bool> Update(OrderForUpdateDto entityForUpdate);
        Task<bool> UpdateClient(ClientUpdated client);
    }
}
