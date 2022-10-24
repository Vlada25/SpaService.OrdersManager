using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Database.Commands.Feedbacks;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbacksManager.Database.Commands.Feedbacks.Handlers
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, bool>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public UpdateFeedbackCommandHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Feedbacks.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);

            if (entity is null)
            {
                return false;
            }

            var feedback = new Feedback
            {
                Id = request.Id,
                Comment = request.Comment,
                Mark = request.Mark,
                OrderId = entity.OrderId
            };

            _dbContext.Feedbacks.Update(feedback);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
