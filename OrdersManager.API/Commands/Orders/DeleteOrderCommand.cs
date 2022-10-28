using MediatR;

namespace OrdersManager.API.Commands.Orders
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
