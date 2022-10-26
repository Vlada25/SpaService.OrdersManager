using MediatR;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Schedules
{
    public class GetSchedulesByServiceIdQuery : IRequest<IEnumerable<Schedule>>
    {
        public Guid ServiceId { get; set; }
    }
}
