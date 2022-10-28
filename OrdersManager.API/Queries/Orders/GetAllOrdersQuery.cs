using MediatR;
using OrdersManager.DTO.Order;

namespace OrdersManager.API.Queries.Orders
{
    public record GetAllOrdersQuery : IRequest<IEnumerable<OrderDto>>
    {
    }
}
