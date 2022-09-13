using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Person;

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
