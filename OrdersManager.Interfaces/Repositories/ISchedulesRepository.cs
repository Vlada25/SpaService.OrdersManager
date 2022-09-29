using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface ISchedulesRepository
    {
        Task<IEnumerable<Schedule>> GetAll(bool trackChanges);
        Task<Schedule> GetById(Guid id, bool trackChanges);
        Task<IEnumerable<Schedule>> GetByMasterId(Guid masterId);
        Task<IEnumerable<Schedule>> GetByServiceId(Guid serviceId);
        Task<IEnumerable<Schedule>> GetByAddressId(Guid addressId);
        Task<IEnumerable<Schedule>> GetByServiceTypeId(Guid serviceTypeId);
        Task Create(Schedule entity);
        void Update(Schedule entity);
        void Delete(Schedule entity);
    }
}
