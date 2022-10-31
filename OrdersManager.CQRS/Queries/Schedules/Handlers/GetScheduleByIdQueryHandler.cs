using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Schedules.Handlers
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, Schedule>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetScheduleByIdQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Schedule> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken) =>
            await _repositoryManager.SchedulesRepository.GetById(request.Id, false, cancellationToken);
    }
}
