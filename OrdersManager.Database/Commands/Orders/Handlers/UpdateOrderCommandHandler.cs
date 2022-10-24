using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database.Commands.Orders;
using OrdersManager.Domain.Extensions;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Commands.Orders.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {
        private readonly OrdersManagerDbContext _dbContext;
        private readonly ILoggingService _loggingService;

        public UpdateOrderCommandHandler(OrdersManagerDbContext dbContext,
            ILoggingService loggingService)
        {
            _dbContext = dbContext;
            _loggingService = loggingService;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);

            if (entity is null)
            {
                return false;
            }

            var order = new Order
            {
                Id = request.Id,
                ClientId = entity.ClientId,
                ScheduleId = entity.ScheduleId,
                Status = EnumExtensions.SetOrderStatus(request.Status),
                ClientSurname = request.ClientSurname,
                ClientName = request.ClientName
            };

            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            await _loggingService.SendUpdatedMessage(order);

            return true;
        }
    }
}
