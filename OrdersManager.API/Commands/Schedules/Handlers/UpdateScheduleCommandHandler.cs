using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Commands.Schedules.Handlers
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, bool>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public UpdateScheduleCommandHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Schedules.AsNoTracking().FirstOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);

            if (entity is null)
            {
                return false;
            }

            var schedule = new Schedule
            {
                Id = request.Id,
                MasterId = entity.MasterId,
                ServiceId = entity.ServiceId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                MasterName = request.MasterName,
                MasterSurname = request.MasterSurname,
                ServiceName = request.ServiceName,
                ServicePrice = request.ServicePrice,
                Address = request.Address,
                AddressId = request.AddressId,
                ServiceTypeId = request.ServiceTypeId
            };

            _dbContext.Schedules.Update(schedule);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
