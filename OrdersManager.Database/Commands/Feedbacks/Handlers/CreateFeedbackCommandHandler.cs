using MediatR;
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
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Feedback>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public CreateFeedbackCommandHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Feedback> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = new Feedback
            {
                Id = new Guid(),
                Comment = request.Comment,
                Mark = request.Mark,
                OrderId = request.OrderId
            };

            await _dbContext.Feedbacks.AddAsync(feedback, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return feedback;
        }
    }
}
