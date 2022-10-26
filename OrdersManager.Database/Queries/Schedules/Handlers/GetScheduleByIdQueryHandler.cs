using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Schedules.Handlers
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
