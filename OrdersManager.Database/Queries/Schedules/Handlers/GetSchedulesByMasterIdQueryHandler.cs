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
    public class GetSchedulesByMasterIdQueryHandler : IRequestHandler<GetSchedulesByMasterIdQuery, IEnumerable<Schedule>>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetSchedulesByMasterIdQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetSchedulesByMasterIdQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Schedules.Where(s => s.MasterId.Equals(request.MasterId)).ToListAsync(cancellationToken);
    }
}
