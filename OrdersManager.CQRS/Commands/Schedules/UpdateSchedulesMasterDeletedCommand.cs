using MediatR;

namespace OrdersManager.CQRS.Commands.Schedules
{
    public class UpdateSchedulesMasterDeletedCommand : IRequest
    {
        public Guid MasterId { get; set; }
    }
}
