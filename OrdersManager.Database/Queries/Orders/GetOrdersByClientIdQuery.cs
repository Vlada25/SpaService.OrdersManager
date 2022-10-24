using MediatR;
using OrdersManager.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Orders
{
    public class GetOrdersByClientIdQuery : IRequest<IEnumerable<OrderDto>>
    {
        public Guid ClientId { get; set; }
    }
}
