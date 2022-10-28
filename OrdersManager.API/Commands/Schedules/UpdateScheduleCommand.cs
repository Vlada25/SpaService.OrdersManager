using MediatR;

namespace OrdersManager.API.Commands.Schedules
{
    public class UpdateScheduleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MasterSurname { get; set; }
        public string MasterName { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        public string Address { get; set; }
        public Guid AddressId { get; set; }
        public Guid ServiceTypeId { get; set; }
    }
}
