using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Database.Repositories
{
    public class SchedulesRepository : BaseRepository<Schedule>, ISchedulesRepository
    {
        public SchedulesRepository(OrdersManagerDbContext dbContext)
            : base(dbContext) { }

        public void Create(Schedule entity) => CreateEntity(entity);

        public IEnumerable<Schedule> GetAll(bool trackChanges) =>
            GetAllEntities(trackChanges);

        public Schedule GetById(Guid id, bool trackChanges) =>
            GetByCondition(sch => sch.Id.Equals(id), trackChanges).SingleOrDefault();

        public void Delete(Schedule entity) => DeleteEntity(entity);

        public IEnumerable<Schedule> GetByMasterId(Guid masterId) =>
            GetByCondition(sch => sch.MasterId.Equals(masterId), false);

        public IEnumerable<Schedule> GetByServiceId(Guid serviceId) =>
            GetByCondition(sch => sch.ServiceId.Equals(serviceId), false);
    }
}
