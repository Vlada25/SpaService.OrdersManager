using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Feedbacks.Handlers
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteFeedbackCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _repositoryManager.FeedbacksRepository.GetById(request.Id, false, cancellationToken);

            if (feedback is null)
            {
                return false;
            }

            _repositoryManager.FeedbacksRepository.Delete(feedback);
            await _repositoryManager.Save(cancellationToken);

            return true;
        }
    }
}
