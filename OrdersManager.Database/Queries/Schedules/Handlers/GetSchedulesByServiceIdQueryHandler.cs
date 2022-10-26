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
