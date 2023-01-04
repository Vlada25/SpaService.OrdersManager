using OrdersManager.Interfaces.Repositories;

namespace OrdersManager.Interfaces
{
    public interface IRepositoryManager
    {
        IOrdersRepository OrdersRepository { get; }
        IFeedbacksRepository FeedbacksRepository { get; }
        ISchedulesRepository SchedulesRepository { get; }

        Task Save(CancellationToken cancellationToken);
    }
}
