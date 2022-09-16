using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface IFeedbacksRepository
    {
        Task<IEnumerable<Feedback>> GetAll(bool trackChanges);
        Task<Feedback> GetById(Guid id, bool trackChanges);
        Task Create(Feedback entity);
        void Delete(Feedback entity);
    }
}
