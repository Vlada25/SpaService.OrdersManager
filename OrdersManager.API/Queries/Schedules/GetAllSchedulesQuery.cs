using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Schedules
{
    public class GetAllSchedulesQuery : IRequest<IEnumerable<Schedule>>
    {
    }
}
