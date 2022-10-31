using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class UpdateSchedulesServiceDeletedCommandHandler : IRequestHandler<UpdateSchedulesServiceDeletedCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateSchedulesServiceDeletedCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateSchedulesServiceDeletedCommand request, CancellationToken cancellationToken)
        {
            var schedules = await _repositoryManager.SchedulesRepository.GetByServiceId(request.ScheduleId, cancellationToken);

            foreach (var schedule in schedules)
            {
                schedule.ServiceId = Guid.Empty;
                _repositoryManager.SchedulesRepository.Update(schedule);
            }

            await _repositoryManager.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
