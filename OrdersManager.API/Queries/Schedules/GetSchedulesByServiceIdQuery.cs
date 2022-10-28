using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Schedules
{
    public class GetSchedulesByServiceIdQuery : IRequest<IEnumerable<Schedule>>
    {
        public Guid ServiceId { get; set; }
    }
}
