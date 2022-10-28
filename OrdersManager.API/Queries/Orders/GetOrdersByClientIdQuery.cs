using MediatR;
using OrdersManager.DTO.Order;

namespace OrdersManager.API.Queries.Orders
{
    public class GetOrdersByClientIdQuery : IRequest<IEnumerable<OrderDto>>
    {
        public Guid ClientId { get; set; }
    }
}
