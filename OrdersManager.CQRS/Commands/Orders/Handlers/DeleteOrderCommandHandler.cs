using MediatR;
using OrdersManager.Interfaces;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.CQRS.Commands.Orders.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggingService _loggingService;

        public DeleteOrderCommandHandler(IRepositoryManager repositoryManager,
            ILoggingService loggingService)
        {
            _repositoryManager = repositoryManager;
            _loggingService = loggingService;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repositoryManager.OrdersRepository.GetById(request.Id, false, cancellationToken);

            if (order is null)
            {
                return false;
            }

            _repositoryManager.OrdersRepository.Delete(order);
            await _repositoryManager.Save(cancellationToken);

            await _loggingService.SendDeletedMessage(order);

            return true;
        }
    }
}
