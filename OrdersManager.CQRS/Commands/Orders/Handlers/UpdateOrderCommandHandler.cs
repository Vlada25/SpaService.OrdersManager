using AutoMapper;
using MediatR;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.CQRS.Commands.Orders.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggingService _loggingService;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IRepositoryManager repositoryManager,
            ILoggingService loggingService,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggingService = loggingService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repositoryManager.OrdersRepository.GetById(request.Id, true, cancellationToken);

            if (order is null)
            {
                return false;
            }

            _mapper.Map(request, order);

            _repositoryManager.OrdersRepository.Update(order);
            await _repositoryManager.Save(cancellationToken);

            await _loggingService.SendUpdatedMessage(order);

            return true;
        }
    }
}
