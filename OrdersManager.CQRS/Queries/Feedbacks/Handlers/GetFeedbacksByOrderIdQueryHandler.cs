using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Feedbacks.Handlers
{
    public class GetFeedbacksByOrderIdQueryHandler : IRequestHandler<GetFeedbacksByOrderIdQuery, IEnumerable<Feedback>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetFeedbacksByOrderIdQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Feedback>> Handle(GetFeedbacksByOrderIdQuery request, CancellationToken cancellationToken) =>
            await _repositoryManager.FeedbacksRepository.GetByOrderId(request.OrderId, false, cancellationToken);
    }
}
