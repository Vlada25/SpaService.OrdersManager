using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Schedules.Handlers
{
    public class GetSchedulesByServiceIdQueryHandler : IRequestHandler<GetSchedulesByServiceIdQuery, IEnumerable<Schedule>>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetSchedulesByServiceIdQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetSchedulesByServiceIdQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Schedules.Where(s => s.ServiceId.Equals(request.ServiceId)).ToListAsync(cancellationToken);
    }
}
