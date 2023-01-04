using MediatR;

namespace OrdersManager.CQRS.Commands.Schedules
{
    public class UpdateAddressScheduleCommand : IRequest
    {
        public Guid AddressId { get; set; }

        public string Address { get; set; }
    }
}
