using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Schedules.Handlers
{
    public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, Schedule>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetScheduleByIdQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Schedule> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Schedules.FirstOrDefaultAsync(f => f.Id.Equals(request.Id), cancellationToken);
    }
}
