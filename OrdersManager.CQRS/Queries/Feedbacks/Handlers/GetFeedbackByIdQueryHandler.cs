using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Feedbacks.Handlers
{
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, Feedback>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetFeedbackByIdQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Feedback> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken) =>
            await _repositoryManager.FeedbacksRepository.GetById(request.Id, false, cancellationToken);
    }
}
