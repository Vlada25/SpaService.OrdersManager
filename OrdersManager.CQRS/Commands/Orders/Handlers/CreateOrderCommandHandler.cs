using MediatR;
using OrdersManager.Domain.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.CQRS.Commands.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggingService _loggingService;

        public CreateOrderCommandHandler(IRepositoryManager repositoryManager,
            ILoggingService loggingService)
        {
            _repositoryManager = repositoryManager;
            _loggingService = loggingService;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = new Guid(),
                ClientId = request.ClientId,
                ScheduleId = request.ScheduleId,
                Status = EnumExtensions.SetOrderStatus(request.Status),
                ClientSurname = request.ClientSurname,
                ClientName = request.ClientName
            };

            await _repositoryManager.OrdersRepository.Create(order, cancellationToken);

            await _loggingService.SendCreatedMessage(order);

            return order;
        }
    }
}
