using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Database.Repositories
{
    public class OrdersRepository : BaseRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(Order entity, CancellationToken cancellationToken) =>
            await CreateEntity(entity, cancellationToken);

        public async Task<IEnumerable<Order>> GetAll(bool trackChanges, CancellationToken cancellationToken) =>
            await GetAllEntities(trackChanges).ToListAsync(cancellationToken);

        public async Task<Order> GetById(Guid id, bool trackChanges, CancellationToken cancellationToken) =>
            await GetByCondition(o => o.Id.Equals(id), trackChanges).SingleOrDefaultAsync(cancellationToken);

        public void Delete(Order entity) => DeleteEntity(entity);

        public async Task<IEnumerable<Order>> GetByClientId(Guid clientId, CancellationToken cancellationToken) =>
            await GetByCondition(o => o.ClientId.Equals(clientId), false).ToListAsync(cancellationToken);

        public void Update(Order entity) =>
            UpdateEntity(entity);

        public async Task<Order> GetByScheduleId(Guid scheduleId, CancellationToken cancellationToken) =>
            await GetByCondition(o => o.ScheduleId.Equals(scheduleId), false).SingleOrDefaultAsync(cancellationToken);
    }
}
