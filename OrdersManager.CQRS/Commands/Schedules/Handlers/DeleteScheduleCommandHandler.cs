using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;

        public DeleteScheduleCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _repositoryManager.SchedulesRepository.GetById(request.Id, false, cancellationToken);

            if (schedule is null)
            {
                return false;
            }

            _repositoryManager.SchedulesRepository.Delete(schedule);
            await _repositoryManager.Save(cancellationToken);

            return true;
        }
    }
}
