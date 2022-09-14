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

            _schedulesService.DeleteByServiceId(message.Id);
        }
    }
}
