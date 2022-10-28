using MediatR;
using Microsoft.EntityFrameworkCore;
using OrdersManager.Database;

namespace OrdersManager.API.Commands.Schedules.Handlers
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, bool>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public DeleteScheduleCommandHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _dbContext.Schedules.FirstOrDefaultAsync(o => o.Id.Equals(request.Id), cancellationToken);

            if (schedule is null)
            {
                return false;
            }

            _dbContext.Schedules.Remove(schedule);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
