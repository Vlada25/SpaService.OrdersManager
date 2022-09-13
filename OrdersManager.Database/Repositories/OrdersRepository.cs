using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(Order entity) => CreateEntity(entity);

        public IEnumerable<Order> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges);

        public Order GetById(Guid id, bool trackChanges) =>
            GetByCondition(fm => fm.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(Order entity) => DeleteEntity(entity);

        public Order GetByClientId(Guid clientId) =>
            GetByCondition(fm => fm.ClientId.Equals(clientId), false).SingleOrDefault();
    }
}
