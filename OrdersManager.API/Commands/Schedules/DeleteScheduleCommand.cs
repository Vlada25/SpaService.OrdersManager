using MediatR;

namespace OrdersManager.API.Commands.Schedules
{
    public class DeleteScheduleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
