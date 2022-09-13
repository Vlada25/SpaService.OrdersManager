using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulesManager.Messaging.Consumers
{
    public class MasterDeletedConsumer : IConsumer<MasterDeleted>
    {
        private readonly ISchedulesService _schedulesService;

        public MasterDeletedConsumer(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        public async Task Consume(ConsumeContext<MasterDeleted> context)
        {
            var message = context.Message;

            _schedulesService.DeleteByMasterId(message.Id);
        }
    }
}
