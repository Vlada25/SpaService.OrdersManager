using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Queries.Schedules
{
    public class GetSchedulesByAddressIdQuery : IRequest<IEnumerable<Schedule>>
    {
        public Guid AddressId { get; set; }
    }
}
