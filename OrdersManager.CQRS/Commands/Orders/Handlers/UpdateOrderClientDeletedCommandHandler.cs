using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Orders.Handlers
{
    public class UpdateOrderClientDeletedCommandHandler : IRequestHandler<UpdateOrderClientDeletedCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateOrderClientDeletedCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateOrderClientDeletedCommand request, CancellationToken cancellationToken)
        {
            var orders = await _repositoryManager.OrdersRepository.GetByClientId(request.ClientId, cancellationToken);

            foreach (var order in orders)
            {
                order.ClientId = Guid.Empty;
                _repositoryManager.OrdersRepository.Update(order);
            }

            await _repositoryManager.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
