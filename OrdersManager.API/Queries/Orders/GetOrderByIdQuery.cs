using MediatR;
using OrdersManager.DTO.Order;

namespace OrdersManager.API.Queries.Orders
{
    public record GetOrderByIdQuery : IRequest<OrderDto>
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ScheduleId { get; set; }
        public string Status { get; set; }
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
    }
}
