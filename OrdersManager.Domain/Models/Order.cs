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
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
        public Schedule Schedule { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
