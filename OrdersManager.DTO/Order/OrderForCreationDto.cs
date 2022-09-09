using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.DTO.Order
{
    public class OrderForCreationDto
    {
        public Guid ClientId { get; set; }
        public Guid ScheduleId { get; set; }
        public string Status { get; set; }
        public string ClientSurname { get; set; }
        public string ClientName { get; set; }
    }
}
