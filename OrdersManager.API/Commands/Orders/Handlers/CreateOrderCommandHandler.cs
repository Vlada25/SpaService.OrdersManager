using MediatR;
using OrdersManager.Database;
using OrdersManager.Domain.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Logging;

namespace OrdersManager.API.Commands.Orders.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly OrdersManagerDbContext _dbContext;
        private readonly ILoggingService _loggingService;

        public CreateOrderCommandHandler(OrdersManagerDbContext dbContext,
            ILoggingService loggingService)
        {
            _dbContext = dbContext;
            _loggingService = loggingService;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = new Guid(),
                ClientId = request.ClientId,
                ScheduleId = request.ScheduleId,
                Status = EnumExtensions.SetOrderStatus(request.Status),
                ClientSurname = request.ClientSurname,
                ClientName = request.ClientName
            };

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _loggingService.SendCreatedMessage(order);

            return order;
        }
    }
}
