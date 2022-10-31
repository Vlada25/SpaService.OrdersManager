using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Queries.Schedules
{
    public class GetAllSchedulesQuery : IRequest<IEnumerable<Schedule>>
    {
    }
}
