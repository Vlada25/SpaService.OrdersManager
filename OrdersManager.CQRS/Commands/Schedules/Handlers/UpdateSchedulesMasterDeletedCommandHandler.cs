using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class UpdateSchedulesMasterDeletedCommandHandler : IRequestHandler<UpdateSchedulesMasterDeletedCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateSchedulesMasterDeletedCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateSchedulesMasterDeletedCommand request, CancellationToken cancellationToken)
        {
            var schedules = await _repositoryManager.SchedulesRepository.GetByMasterId(request.MasterId, cancellationToken);

            foreach (var schedule in schedules)
            {
                schedule.MasterId = Guid.Empty;
                _repositoryManager.SchedulesRepository.Update(schedule);
            }

            await _repositoryManager.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
