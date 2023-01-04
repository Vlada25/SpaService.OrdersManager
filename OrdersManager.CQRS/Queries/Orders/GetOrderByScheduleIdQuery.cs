using MediatR;
using OrdersManager.DTO.Order;

namespace OrdersManager.CQRS.Queries.Orders
{
    public class GetOrderByScheduleIdQuery : IRequest<OrderDto>
    {
        public Guid ScheduleId { get; set; }
    }
}
