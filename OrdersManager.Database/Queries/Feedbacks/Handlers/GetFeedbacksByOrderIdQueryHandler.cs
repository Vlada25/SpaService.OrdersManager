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
    public class GetFeedbacksByOrderIdQueryHandler : IRequestHandler<GetFeedbacksByOrderIdQuery, IEnumerable<Feedback>>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetFeedbacksByOrderIdQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Feedback>> Handle(GetFeedbacksByOrderIdQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Feedbacks.Where(f => f.OrderId.Equals(request.OrderId)).ToListAsync(cancellationToken);
    }
}
