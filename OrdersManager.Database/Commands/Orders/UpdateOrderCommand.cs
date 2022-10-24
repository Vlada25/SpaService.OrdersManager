using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Commands.Orders
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
    }
}
