using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface ISchedulesRepository
    {
        IEnumerable<Schedule> GetAll(bool trackChanges);
        Schedule GetById(Guid id, bool trackChanges);
        Schedule GetByMasterId(Guid masterId);
        void Create(Schedule entity);
        void Delete(Schedule entity);
    }
}
