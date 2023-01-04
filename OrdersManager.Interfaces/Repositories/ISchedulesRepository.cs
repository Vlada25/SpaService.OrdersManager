using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface ISchedulesRepository
    {
        Task<IEnumerable<Schedule>> GetAll(bool trackChanges, CancellationToken cancellationToken);
        Task<Schedule> GetById(Guid id, bool trackChanges, CancellationToken cancellationToken);
        Task<IEnumerable<Schedule>> GetByMasterId(Guid masterId, CancellationToken cancellationToken);
        Task<IEnumerable<Schedule>> GetByServiceId(Guid serviceId, CancellationToken cancellationToken);
        Task<IEnumerable<Schedule>> GetByAddressId(Guid addressId, CancellationToken cancellationToken);
        Task<IEnumerable<Schedule>> GetByServiceTypeId(Guid serviceTypeId, CancellationToken cancellationToken);
        Task Create(Schedule entity, CancellationToken cancellationToken);
        void Update(Schedule entity);
        void Delete(Schedule entity);
    }
}
