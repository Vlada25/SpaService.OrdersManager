using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Database.Repositories
{
    public class FeedbacksRepository : BaseRepository<Feedback>, IFeedbacksRepository
    {
        public FeedbacksRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(Feedback entity) => await CreateEntity(entity);

        public async Task<IEnumerable<Feedback>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<Feedback> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(fm => fm.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(Feedback entity) => DeleteEntity(entity);

        public void Update(Feedback entity) =>
            UpdateEntity(entity);
    }
}
