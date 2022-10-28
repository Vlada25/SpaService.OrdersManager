using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Feedbacks.Handlers
{
    public class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, IEnumerable<Feedback>>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public GetAllFeedbacksQueryHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Feedback>> Handle(GetAllFeedbacksQuery request, CancellationToken cancellationToken) =>
            await _dbContext.Feedbacks.ToListAsync(cancellationToken);
    }
}
