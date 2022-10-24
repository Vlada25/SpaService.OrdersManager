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
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, Feedback>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetFeedbackByIdQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Feedback> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Feedbacks.FirstOrDefaultAsync(f => f.Id.Equals(request.Id));
    }
}
