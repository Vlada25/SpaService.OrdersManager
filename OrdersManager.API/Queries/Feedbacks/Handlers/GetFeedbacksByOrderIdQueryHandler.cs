using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Feedbacks.Handlers
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
