using AutoMapper;
using MediatR;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, bool>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public UpdateScheduleCommandHandler(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _repositoryManager.SchedulesRepository.GetById(request.Id, true, cancellationToken);

            if (schedule is null)
            {
                return false;
            }

            _mapper.Map(request, schedule);

            _repositoryManager.SchedulesRepository.Update(schedule);
            await _repositoryManager.Save(cancellationToken);

            return true;
        }
    }
}
