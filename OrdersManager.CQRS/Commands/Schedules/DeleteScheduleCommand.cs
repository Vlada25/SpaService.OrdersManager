using MediatR;

namespace OrdersManager.CQRS.Commands.Schedules
{
    public class DeleteScheduleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
