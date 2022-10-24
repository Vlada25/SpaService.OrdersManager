using MediatR;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Commands.Orders
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
