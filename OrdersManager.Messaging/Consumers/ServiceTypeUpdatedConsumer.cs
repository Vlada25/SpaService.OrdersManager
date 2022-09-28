using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.ServiceType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Messaging.Consumers
{
    public class ServiceTypeUpdatedConsumer : IConsumer<ServiceTypeUpdated>
    {
        private readonly ISchedulesService _schedulesService;

        public ServiceTypeUpdatedConsumer(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        public async Task Consume(ConsumeContext<ServiceTypeUpdated> context)
        {
            var message = context.Message;

            var schedules = await _schedulesService.GetByServiceTypeId(message.Id);
            foreach (var schedule in schedules)
            {
                schedule.ServiceName = message.Name;
            }

            await _schedulesService.UpdateSchedules(schedules);
        }
    }
}
