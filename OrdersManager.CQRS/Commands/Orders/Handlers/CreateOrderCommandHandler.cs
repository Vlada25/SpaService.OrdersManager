using AutoMapper;
using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.CQRS.Commands.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggingService _loggingService;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IRepositoryManager repositoryManager,
            ILoggingService loggingService,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggingService = loggingService;
            _mapper = mapper;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);

            await _repositoryManager.OrdersRepository.Create(order, cancellationToken);

            await _loggingService.SendCreatedMessage(order);

            return order;
        }
    }
}
