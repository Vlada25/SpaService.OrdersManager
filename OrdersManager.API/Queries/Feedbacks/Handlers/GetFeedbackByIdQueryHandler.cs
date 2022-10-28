using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Feedbacks.Handlers
{
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, Feedback>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetFeedbackByIdQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Feedback> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Feedbacks.FirstOrDefaultAsync(f => f.Id.Equals(request.Id), cancellationToken);
    }
}
