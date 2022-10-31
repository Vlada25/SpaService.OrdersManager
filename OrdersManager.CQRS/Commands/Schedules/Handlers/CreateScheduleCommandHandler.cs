using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Schedule>
    {
        private readonly IRepositoryManager _repositoryManager;

        public CreateScheduleCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Schedule> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new Schedule
            {
                Id = new Guid(),
                MasterId = request.MasterId,
                ServiceId = request.ServiceId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                MasterName = request.MasterName,
                MasterSurname = request.MasterSurname,
                ServiceName = request.ServiceName,
                ServicePrice = request.ServicePrice,
                Address = request.Address,
                AddressId = request.AddressId,
                ServiceTypeId = request.ServiceTypeId
            };

            await _repositoryManager.SchedulesRepository.Create(schedule, cancellationToken);

            return schedule;
        }
    }
}
