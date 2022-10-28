using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Address;

namespace OrdersManager.Messaging.Consumers
{
    public class AddressUpdatedConsumer : IConsumer<AddressUpdated>
    {
        private readonly ISchedulesService _schedulesService;

        public AddressUpdatedConsumer(ISchedulesService schedulesService)
        {
            _schedulesService = schedulesService;
        }

        public async Task Consume(ConsumeContext<AddressUpdated> context)
        {
            var message = context.Message;

            var schedules = await _schedulesService.GetByAddressId(message.Id);
            foreach (var schedule in schedules)
            {
                schedule.Address = message.Address;
            }

            await _schedulesService.UpdateSchedules(schedules);
        }
    }
}
