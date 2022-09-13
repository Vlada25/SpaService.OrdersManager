using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;

namespace OrdersManager.Interfaces.Services
{
    public interface IFeedbacksService
    {
        IEnumerable<Feedback> GetAll();
        Feedback GetById(Guid id);
        Feedback Create(FeedbackForCreationDto entityForCreation);
        bool Delete(Guid id);
        bool Update(FeedbackForUpdateDto entityForUpdate);
    }
}
