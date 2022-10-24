using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Feedbacks.Handlers
{
    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, IEnumerable<Feedback>>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetAllFeedbacksQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Feedback>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Feedbacks.ToListAsync();
    }
}
