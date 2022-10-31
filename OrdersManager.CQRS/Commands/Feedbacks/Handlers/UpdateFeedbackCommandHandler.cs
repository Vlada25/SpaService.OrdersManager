using AutoMapper;
using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Feedbacks.Handlers
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateFeedbackCommandHandler(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _repositoryManager.FeedbacksRepository.GetById(request.Id, false, cancellationToken);

            if (feedback is null)
            {
                return false;
            }

            _mapper.Map(request, feedback);

            _repositoryManager.FeedbacksRepository.Update(feedback);
            await _repositoryManager.Save(cancellationToken);

            return true;
        }
    }
}
