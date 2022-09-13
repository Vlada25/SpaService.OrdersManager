using OrdersManager.Domain.Models;
using OrdersManager.DTO.Order;
using SpaService.Domain.Messages.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Interfaces.Services
{
    public interface IOrdersService
    {
        IEnumerable<Order> GetAll();
        Order GetById(Guid id);
        Order Create(OrderForCreationDto entityForCreation);
        bool Delete(Guid id);
        bool DeleteByClientId(Guid clientId);
        bool Update(OrderForUpdateDto entityForUpdate);
        bool UpdateClient(ClientUpdated client);
    }
}
