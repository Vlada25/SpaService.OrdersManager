using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Database.Repositories
{
    public class SchedulesRepository : BaseRepository<Schedule>, ISchedulesRepository
    {
        public SchedulesRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public async Task Create(Schedule entity) => await CreateEntity(entity);

        public async Task<IEnumerable<Schedule>> GetAll(bool trackChanges) =>
            await GetAllEntities(trackChanges).ToListAsync();

        public async Task<Schedule> GetById(Guid id, bool trackChanges) =>
            await GetByCondition(sch => sch.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void Delete(Schedule entity) => DeleteEntity(entity);

        public async Task<IEnumerable<Schedule>> GetByMasterId(Guid masterId) =>
            await GetByCondition(sch => sch.MasterId.Equals(masterId), false).ToListAsync();

        public async Task<IEnumerable<Schedule>> GetByServiceId(Guid serviceId) =>
            await GetByCondition(sch => sch.ServiceId.Equals(serviceId), false).Include(sh => sh.Order).ToListAsync();

        public void Update(Schedule entity) =>
            UpdateEntity(entity);

        public async Task<IEnumerable<Schedule>> GetByAddressId(Guid addressId) =>
            await GetByCondition(sch => sch.Address.Equals(addressId), false).ToListAsync();

        public async Task<IEnumerable<Schedule>> GetByServiceTypeId(Guid serviceTypeId) =>
            await GetByCondition(sch => sch.ServiceTypeId.Equals(serviceTypeId), false).ToListAsync();
    }
}
