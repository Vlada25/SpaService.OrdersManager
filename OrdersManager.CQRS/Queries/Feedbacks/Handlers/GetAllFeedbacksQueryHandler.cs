using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Feedbacks.Handlers
{
    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, IEnumerable<Feedback>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetAllFeedbacksQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Feedback>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken) =>
            await _repositoryManager.FeedbacksRepository.GetAll(false, cancellationToken);
    }
}
