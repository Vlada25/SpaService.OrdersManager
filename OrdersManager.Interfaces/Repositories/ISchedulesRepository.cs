using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface ISchedulesRepository
    {
        IEnumerable<Schedule> GetAll(bool trackChanges);
        Schedule GetById(Guid id, bool trackChanges);
        IEnumerable<Schedule> GetByMasterId(Guid masterId);
        IEnumerable<Schedule> GetByServiceId(Guid serviceId);
        void Create(Schedule entity);
        void Delete(Schedule entity);
    }
}
