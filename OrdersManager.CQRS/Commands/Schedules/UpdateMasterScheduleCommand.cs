using MediatR;

namespace OrdersManager.CQRS.Commands.Schedules
{
    public class UpdateMasterScheduleCommand : IRequest
    {
        public Guid MasterId { get; set; }
        public string MasterName { get; set; }

        public string MasterSurname { get; set; }
    }
}
