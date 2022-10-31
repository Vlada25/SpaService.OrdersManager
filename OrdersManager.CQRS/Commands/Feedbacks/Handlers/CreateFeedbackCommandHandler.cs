using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Feedbacks.Handlers
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Feedback>
    {
        private readonly IRepositoryManager _repositoryManager;

        public CreateFeedbackCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Feedback> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = new Feedback
            {
                Id = new Guid(),
                Comment = request.Comment,
                Mark = request.Mark,
                OrderId = request.OrderId
            };

            await _repositoryManager.FeedbacksRepository.Create(feedback, cancellationToken);

            return feedback;
        }
    }
}
