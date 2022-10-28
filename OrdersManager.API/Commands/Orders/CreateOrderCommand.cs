using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Commands.Orders
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Guid ClientId { get; set; }
        public Guid ScheduleId { get; set; }
        public string Status { get; set; }
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
    }
}
