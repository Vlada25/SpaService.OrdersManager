using MediatR;
using OrdersManager.DTO.Order;

namespace OrdersManager.CQRS.Queries.Orders
{
    public record GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
    }
}
