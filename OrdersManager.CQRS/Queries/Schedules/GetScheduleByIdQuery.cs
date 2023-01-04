using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Queries.Schedules
{
    public class GetScheduleByIdQuery : IRequest<Schedule>
    {
        public Guid Id { get; set; }
    }
}
