using MediatR;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces;

namespace OrdersManager.CQRS.Queries.Schedules.Handlers
{
    public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, IEnumerable<Schedule>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetAllSchedulesQueryHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken) =>
            await _repositoryManager.SchedulesRepository.GetAll(false, cancellationToken);
    }
}
