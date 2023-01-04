using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Queries.Schedules
{
    public class GetSchedulesByMasterIdQuery : IRequest<IEnumerable<Schedule>>
    {
        public Guid MasterId { get; set; }
    }
}
