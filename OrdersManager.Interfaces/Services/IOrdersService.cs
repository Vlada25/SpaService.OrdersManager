using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Interfaces.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderDto>> GetAll();
        Task<OrderDto> GetById(Guid id);
        Task<IEnumerable<OrderDto>> GetByClientId(Guid clientId);
        Task<OrderDto> GetByScheduleId(Guid scheduleId);
        Task<OrderDto> Create(OrderForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> DeleteByClientId(Guid clientId);
        Task<bool> Update(Guid id, OrderForUpdateDto entityForUpdate);
        Task<bool> UpdateOrders(IEnumerable<Order> entities);
        Task<bool> UpdateClient(ClientUpdated client);
    }
}
