using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Schedules.Handlers
{
    public class GetSchedulesByMasterIdQueryHandler : IRequestHandler<GetSchedulesByMasterIdQuery, IEnumerable<Schedule>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetSchedulesByMasterIdQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetSchedulesByMasterIdQuery request, CancellationToken cancellationToken) =>
            await _repositoryManager.SchedulesRepository.GetByMasterId(request.MasterId, cancellationToken);
    }
}
