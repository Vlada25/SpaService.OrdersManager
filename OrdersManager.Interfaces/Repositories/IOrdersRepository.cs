using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
