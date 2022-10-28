using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Schedules
{
    public class GetSchedulesByMasterIdQuery : IRequest<IEnumerable<Schedule>>
    {
        public Guid MasterId { get; set; }
    }
}
