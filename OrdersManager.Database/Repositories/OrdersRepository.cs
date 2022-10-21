using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Database.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(Order entity) => await CreateEntity(entity);

        public async Task<IEnumerable<Order>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<Order> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(o => o.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(Order entity) => DeleteEntity(entity);

        public async Task<IEnumerable<Order>> GetByClientId(Guid clientId) =>
            await GetByCondition(o => o.ClientId.Equals(clientId), false).ToListAsync();

        public void Update(Order entity) =>
            UpdateEntity(entity);

        public async Task<Order> GetByScheduleId(Guid scheduleId) =>
            await GetByCondition(o => o.ScheduleId.Equals(scheduleId), false).SingleOrDefaultAsync();
    }
}
