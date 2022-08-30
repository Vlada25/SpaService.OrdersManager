using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.DTO.Schedule
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public Guid MasterId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
    }
}
