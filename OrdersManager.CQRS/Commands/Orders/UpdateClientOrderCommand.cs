using MediatR;

namespace OrdersManager.CQRS.Commands.Orders
{
    public class UpdateClientOrderCommand : IRequest<bool>
    {
        public Guid ClientId { get; set; }

        public string ClientName { get; set; }

        public string ClientSurname { get; set; }
    }
}
