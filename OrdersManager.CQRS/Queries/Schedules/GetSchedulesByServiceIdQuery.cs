using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Queries.Schedules
{
    public class GetSchedulesByServiceIdQuery : IRequest<IEnumerable<Schedule>>
    {
        public Guid ServiceId { get; set; }
    }
}
