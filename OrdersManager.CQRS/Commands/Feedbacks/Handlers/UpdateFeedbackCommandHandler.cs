using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Feedbacks.Handlers
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateFeedbackCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.FeedbacksRepository.GetById(request.Id, false, cancellationToken);

            if (entity is null)
            {
                return false;
            }

            var feedback = new Feedback
            {
                Id = request.Id,
                Comment = request.Comment,
                Mark = request.Mark,
                OrderId = entity.OrderId
            };

            _repositoryManager.FeedbacksRepository.Update(feedback);
            await _repositoryManager.Save(cancellationToken);

            return true;
        }
    }
}
