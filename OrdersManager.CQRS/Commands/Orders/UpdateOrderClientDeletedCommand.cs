using MediatR;

namespace OrdersManager.CQRS.Commands.Orders
{
    public class UpdateOrderClientDeletedCommand : IRequest
    {
        public Guid ClientId { get; set; }
    }
}
