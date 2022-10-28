using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;

namespace OrdersManager.API.Commands.Feedbacks.Handlers
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, bool>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public DeleteFeedbackCommandHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(o => o.Id.Equals(request.Id), cancellationToken);

            if (feedback is null)
            {
                return false;
            }

            _dbContext.Feedbacks.Remove(feedback);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
