using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class UpdateMasterScheduleCommandHandler : IRequestHandler<UpdateMasterScheduleCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateMasterScheduleCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateMasterScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedules = await _repositoryManager.SchedulesRepository.GetByMasterId(request.MasterId, cancellationToken);

            foreach (var schedule in schedules)
            {
                schedule.MasterName = request.MasterName;
                schedule.MasterSurname = request.MasterSurname;

                _repositoryManager.SchedulesRepository.Update(schedule);
            }

            await _repositoryManager.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
