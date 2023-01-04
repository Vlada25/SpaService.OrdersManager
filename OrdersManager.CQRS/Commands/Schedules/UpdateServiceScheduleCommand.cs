using MediatR;

namespace OrdersManager.CQRS.Commands.Schedules
{
    public class UpdateServiceScheduleCommand : IRequest
    {
        public Guid ServiceId { get; set; }

        public string ServiceName { get; set; }

        public decimal ServicePrice { get; set; }

        public string ServiceAddress { get; set; }
    }
}
