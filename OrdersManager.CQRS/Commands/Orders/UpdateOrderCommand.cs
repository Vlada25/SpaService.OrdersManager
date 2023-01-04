using MediatR;

namespace OrdersManager.CQRS.Commands.Orders
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
    }
}
