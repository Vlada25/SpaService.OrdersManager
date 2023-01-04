using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Orders.Handlers
{
    public class UpdateClientOrderCommandHandler : IRequestHandler<UpdateClientOrderCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateClientOrderCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> Handle(UpdateClientOrderCommand request, CancellationToken cancellationToken)
        {
            var orders = await _repositoryManager.OrdersRepository.GetByClientId(request.ClientId, cancellationToken);

            if (orders == null)
            {
                return false;
            }

            foreach (var order in orders)
            {
                order.ClientName = request.ClientName;
                order.ClientSurname = request.ClientSurname;

                _repositoryManager.OrdersRepository.Update(order);
            }

            await _repositoryManager.Save(cancellationToken);

            return true;
        }
    }
}
