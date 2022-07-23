using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ScheduleId { get; set; }
    }
}
