using MediatR;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Commands.Schedules.Handlers
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Schedule>
    {
        private readonly OrdersManagerDbContext _dbContext;

        public CreateScheduleCommandHandler(OrdersManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Schedule> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new Schedule
            {
                Id = new Guid(),
                MasterId = request.MasterId,
                ServiceId = request.ServiceId,
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

            await _dbContext.Schedules.AddAsync(schedule, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return schedule;
        }
    }
}
