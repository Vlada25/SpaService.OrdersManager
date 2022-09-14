using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Interfaces.Services
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetAll();
        Order GetById(Guid id);
        Task<Order> Create(OrderForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        bool DeleteByClientId(Guid clientId);
        bool Update(OrderForUpdateDto entityForUpdate);
        bool UpdateClient(ClientUpdated client);
    }
}
