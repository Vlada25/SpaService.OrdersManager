using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface IFeedbacksRepository
    {
        Task<IEnumerable<Feedback>> GetAll(bool trackChanges, CancellationToken cancellationToken);
        Task<Feedback> GetById(Guid id, bool trackChanges, CancellationToken cancellationToken);
        Task<IEnumerable<Feedback>> GetByOrderId(Guid orderId, bool trackChanges, CancellationToken cancellationToken);
        Task Create(Feedback entity, CancellationToken cancellationToken);
        void Delete(Feedback entity);
        void Update(Feedback entity);
    }
}
