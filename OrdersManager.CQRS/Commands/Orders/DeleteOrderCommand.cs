using MediatR;

namespace OrdersManager.CQRS.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
