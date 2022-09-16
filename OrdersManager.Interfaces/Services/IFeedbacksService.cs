using OrdersManager.Domain.Models;
using OrdersManager.DTO.Feedback;

namespace OrdersManager.Interfaces.Services
{
    public interface IFeedbacksService
    {
        Task<IEnumerable<Feedback>> GetAll();
        Task<Feedback> GetById(Guid id);
        Task<Feedback> Create(FeedbackForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> Update(FeedbackForUpdateDto entityForUpdate);
    }
}
