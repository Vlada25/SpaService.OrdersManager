using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;

        public UpdateScheduleCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<bool> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repositoryManager.SchedulesRepository.GetById(request.Id, true, cancellationToken);

            if (entity is null)
            {
                return false;
            }

            var schedule = new Schedule
            {
                Id = request.Id,
                MasterId = entity.MasterId,
                ServiceId = entity.ServiceId,
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

            _repositoryManager.SchedulesRepository.Update(schedule);
            await _repositoryManager.Save(cancellationToken);

            return true;
        }
    }
}
