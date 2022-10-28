using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.API.Commands.Orders.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly OrdersManagerDbContext _dbContext;
        private readonly ILoggingService _loggingService;

        public DeleteOrderCommandHandler(OrdersManagerDbContext dbContext,
            ILoggingService loggingService)
        {
            _dbContext = dbContext;
            _loggingService = loggingService;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id.Equals(request.Id), cancellationToken);

            if (order is null)
            {
                return false;
            }

            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _loggingService.SendDeletedMessage(order);

            return true;
        }
    }
}
