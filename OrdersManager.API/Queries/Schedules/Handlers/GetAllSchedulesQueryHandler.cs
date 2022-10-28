using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Schedules.Handlers
{
    public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, IEnumerable<Schedule>>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetAllSchedulesQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Schedules.ToListAsync(cancellationToken);
    }
}
