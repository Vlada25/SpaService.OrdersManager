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
    public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, IEnumerable<Schedule>>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetAllSchedulesQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Schedule>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Schedules.ToListAsync();
    }
}
