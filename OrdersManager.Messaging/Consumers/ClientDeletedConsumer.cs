using MassTransit;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Messaging.Consumers
{
    public class ClientDeletedConsumer : IConsumer<ClientDeleted>
    {
        private readonly IOrdersService _ordersService;

        public ClientDeletedConsumer(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public async Task Consume(ConsumeContext<ClientDeleted> context)
        {
            var message = context.Message;

            var orders = await _ordersService.GetByClientId(message.Id);

            foreach (var order in orders)
            {
                order.ClientId = Guid.Empty;
            }

            await _ordersService.UpdateOrders(orders);
        }
    }
}
