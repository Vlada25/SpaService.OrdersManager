using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Database.Repositories
{
    public class SchedulesRepository : BaseRepository<Schedule>, ISchedulesRepository
    {
        public SchedulesRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(Schedule entity, CancellationToken cancellationToken) =>
            await CreateEntity(entity, cancellationToken);

        public async Task<IEnumerable<Schedule>> GetAll(bool trackChanges, CancellationToken cancellationToken) =>
            await GetAllEntities(trackChanges).ToListAsync(cancellationToken);

        public async Task<Schedule> GetById(Guid id, bool trackChanges, CancellationToken cancellationToken) =>
            await GetByCondition(sch => sch.Id.Equals(id), trackChanges).SingleOrDefaultAsync(cancellationToken);

        public void Delete(Schedule entity) => DeleteEntity(entity);

        public async Task<IEnumerable<Schedule>> GetByMasterId(Guid masterId, CancellationToken cancellationToken) =>
            await GetByCondition(sch => sch.MasterId.Equals(masterId), false).ToListAsync(cancellationToken);

        public async Task<IEnumerable<Schedule>> GetByServiceId(Guid serviceId, CancellationToken cancellationToken) =>
            await GetByCondition(sch => sch.ServiceId.Equals(serviceId), false)
                .Include(sh => sh.Order).ToListAsync(cancellationToken);

        public void Update(Schedule entity) =>
            UpdateEntity(entity);

        public async Task<IEnumerable<Schedule>> GetByAddressId(Guid addressId, CancellationToken cancellationToken) =>
            await GetByCondition(sch => sch.Address.Equals(addressId), false).ToListAsync(cancellationToken);

        public async Task<IEnumerable<Schedule>> GetByServiceTypeId(Guid serviceTypeId, CancellationToken cancellationToken) =>
            await GetByCondition(sch => sch.ServiceTypeId.Equals(serviceTypeId), false).ToListAsync(cancellationToken);
    }
}
