using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class UpdateAddressScheduleCommandHandler : IRequestHandler<UpdateAddressScheduleCommand>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateAddressScheduleCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Unit> Handle(UpdateAddressScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedules = await _repositoryManager.SchedulesRepository.GetByAddressId(request.AddressId, cancellationToken);

            foreach (var schedule in schedules)
            {
                schedule.Address = request.Address;
                _repositoryManager.SchedulesRepository.Update(schedule);
            }

            await _repositoryManager.Save(cancellationToken);

            return Unit.Value;
        }
    }
}
