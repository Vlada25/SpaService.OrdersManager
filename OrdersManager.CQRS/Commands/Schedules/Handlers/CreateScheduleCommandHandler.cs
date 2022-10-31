using AutoMapper;
using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Commands.Schedules.Handlers
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Schedule>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public CreateScheduleCommandHandler(IRepositoryManager repositoryManager,
            IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<Schedule> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = _mapper.Map<Schedule>(request);

            await _repositoryManager.SchedulesRepository.Create(schedule, cancellationToken);

            return schedule;
        }
    }
}
