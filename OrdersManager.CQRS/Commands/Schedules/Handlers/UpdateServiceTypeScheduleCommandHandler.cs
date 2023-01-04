using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class UpdateServiceTypeScheduleCommandHandler : IRequestHandler<UpdateServiceTypeScheduleCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateServiceTypeScheduleCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateServiceTypeScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedules = await _repositoryManager.SchedulesRepository.GetByServiceTypeId(request.ServiceTypeId, cancellationToken);

            foreach (var schedule in schedules)
            {
                schedule.ServiceName = request.ServiceTypeName;
                _repositoryManager.SchedulesRepository.Update(schedule);
            }

            await _repositoryManager.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
