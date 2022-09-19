using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Messaging.Consumers
{
    public class ServiceDeletedConsumer : IConsumer<ServiceDeleted>
    {
        private readonly ISchedulesService _schedulesService;

        public ServiceDeletedConsumer(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        public async Task Consume(ConsumeContext<ServiceDeleted> context)
        {
            var message = context.Message;

            var schedules = await _schedulesService.GetByServiceId(message.Id);

            foreach (var schedule in schedules)
            {
                schedule.ServiceId = Guid.Empty;
            }

            await _schedulesService.UpdateSchedules(schedules);
        }
    }
}
