using OrdersManager.Domain.Models;

namespace OrdersManager.Interfaces.Repositories
{
    public interface IFeedbacksRepository
    {
        IEnumerable<Feedback> GetAll(bool trackChanges);
        Feedback GetById(Guid id, bool trackChanges);
        void Create(Feedback entity);
        void Delete(Feedback entity);
    }
}
