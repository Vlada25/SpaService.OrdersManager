using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Messaging.Consumers
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
