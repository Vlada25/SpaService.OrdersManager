using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Database.Repositories
{
    public class FeedbacksRepository : BaseRepository<Feedback>, IFeedbacksRepository
    {
        public FeedbacksRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(Feedback entity, CancellationToken cancellationToken) =>
            await CreateEntity(entity, cancellationToken);

        public async Task<IEnumerable<Feedback>> GetAll(bool trackChanges, CancellationToken cancellationToken) =>
            await GetAllEntities(trackChanges).ToListAsync(cancellationToken);

        public async Task<Feedback> GetById(Guid id, bool trackChanges, CancellationToken cancellationToken) =>
            await GetByCondition(f => f.Id.Equals(id), trackChanges).SingleOrDefaultAsync(cancellationToken);

        public void Delete(Feedback entity) => DeleteEntity(entity);

        public void Update(Feedback entity) =>
            UpdateEntity(entity);

        public async Task<IEnumerable<Feedback>> GetByOrderId(Guid orderId, bool trackChanges, CancellationToken cancellationToken) =>
            await GetByCondition(f => f.OrderId.Equals(orderId), false).ToListAsync(cancellationToken);
    }
}
