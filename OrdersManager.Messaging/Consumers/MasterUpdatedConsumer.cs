using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Messaging.Consumers
{
    public class MasterUpdatedConsumer : IConsumer<MasterUpdated>
    {
        private readonly ISchedulesService _schedulesService;

        public MasterUpdatedConsumer(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        public async Task Consume(ConsumeContext<MasterUpdated> context)
        {
            var message = context.Message;


        }
    }
}
