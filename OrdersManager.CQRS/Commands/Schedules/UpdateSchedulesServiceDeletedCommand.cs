using MediatR;

namespace OrdersManager.CQRS.Commands.Schedules
{
    public class UpdateSchedulesServiceDeletedCommand : IRequest
    {
        public Guid ScheduleId { get; set; }
    }
}
