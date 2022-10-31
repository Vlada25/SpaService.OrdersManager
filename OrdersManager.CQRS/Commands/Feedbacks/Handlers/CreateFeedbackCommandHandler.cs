using AutoMapper;
using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Feedbacks.Handlers
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Feedback>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateFeedbackCommandHandler(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Feedback> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = _mapper.Map<Feedback>(request);

            await _repositoryManager.FeedbacksRepository.Create(feedback, cancellationToken);

            return feedback;
        }
    }
}
