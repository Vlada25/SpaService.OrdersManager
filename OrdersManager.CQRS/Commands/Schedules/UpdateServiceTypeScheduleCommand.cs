using MediatR;

namespace OrdersManager.CQRS.Commands.Schedules
{
    public class UpdateServiceTypeScheduleCommand : IRequest
    {
        public Guid ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
    }
}
