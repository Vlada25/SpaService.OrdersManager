using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface ISchedulesRepository
    {
        Task<IEnumerable<Schedule>> GetAll(bool trackChanges);
        Task<Schedule> GetById(Guid id, bool trackChanges);
        Task<IEnumerable<Schedule>> GetByMasterId(Guid masterId);
        Task<IEnumerable<Schedule>> GetByServiceId(Guid serviceId);
        Task Create(Schedule entity);
        void Delete(Schedule entity);
    }
}
