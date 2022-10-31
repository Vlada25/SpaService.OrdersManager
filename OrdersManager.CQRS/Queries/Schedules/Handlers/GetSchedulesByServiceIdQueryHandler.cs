using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Schedules.Handlers
{
    public class GetSchedulesByServiceIdQueryHandler : IRequestHandler<GetSchedulesByServiceIdQuery, IEnumerable<Schedule>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetSchedulesByServiceIdQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetSchedulesByServiceIdQuery request, CancellationToken cancellationToken) =>
            await _repositoryManager.SchedulesRepository.GetByServiceId(request.ServiceId, cancellationToken);
    }
}
