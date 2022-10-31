using MediatR;
using OrdersManager.Domain.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.CQRS.Commands.Orders.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggingService _loggingService;

        public UpdateOrderCommandHandler(IRepositoryManager repositoryManager,
            ILoggingService loggingService)
        {
            _repositoryManager = repositoryManager;
            _loggingService = loggingService;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.OrdersRepository.GetById(request.Id, true, cancellationToken);

            if (entity is null)
            {
                return false;
            }

            var order = new Order
            {
                Id = request.Id,
                ClientId = entity.ClientId,
                ScheduleId = entity.ScheduleId,
                Status = EnumExtensions.SetOrderStatus(request.Status),
                ClientSurname = request.ClientSurname,
                ClientName = request.ClientName
            };

            _repositoryManager.OrdersRepository.Update(order);
            await _repositoryManager.Save(cancellationToken);

            await _loggingService.SendUpdatedMessage(order);

            return true;
        }
    }
}
