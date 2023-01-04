using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class UpdateServiceScheduleCommandHandler : IRequestHandler<UpdateServiceScheduleCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateServiceScheduleCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateServiceScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedules = await _repositoryManager.SchedulesRepository.GetByServiceId(request.ServiceId, cancellationToken);

            foreach (var schedule in schedules)
            {
                schedule.Address = request.ServiceAddress;
                schedule.ServiceName = request.ServiceName;
            }

            await _repositoryManager.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
