using MediatR;
using OrdersManager.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Orders
{
    public class GetOrderByScheduleIdQuery : IRequest<OrderDto>
    {
        public Guid ScheduleId { get; set; }
    }
}
