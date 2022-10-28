using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Service;

namespace OrdersManager.Messaging.Consumers
{
    public class ServiceUpdatedConsumer : IConsumer<ServiceUpdated>
    {
        private readonly ISchedulesService _schedulesService;

        public ServiceUpdatedConsumer(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        public async Task Consume(ConsumeContext<ServiceUpdated> context)
        {
            var message = context.Message;

            await _schedulesService.UpdateService(message);
        }
    }
}
