using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Schedules.Handlers
{
    public class GetSchedulesByAddressIdQueryHandler : IRequestHandler<GetSchedulesByAddressIdQuery, IEnumerable<Schedule>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetSchedulesByAddressIdQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetSchedulesByAddressIdQuery request, CancellationToken cancellationToken) =>
            await _repositoryManager.SchedulesRepository.GetByAddressId(request.AddressId, cancellationToken);
    }
}
