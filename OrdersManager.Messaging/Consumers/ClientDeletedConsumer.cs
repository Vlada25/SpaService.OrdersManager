using AutoMapper;
using MassTransit;
using OrdersManager.Domain.Models;
using OrdersManager.Interfaces.Services;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Messaging.Consumers
{
    public class ClientDeletedConsumer : IConsumer<ClientDeleted>
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;

        public ClientDeletedConsumer(IOrdersService ordersService, IMapper mapper)
        {
            _ordersService = ordersService;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<ClientDeleted> context)
        {
            var message = context.Message;

            var orders = await _ordersService.GetByClientId(message.Id);

            foreach (var order in orders)
            {
                order.ClientId = Guid.Empty;
            }

            await _ordersService.UpdateOrders(_mapper.Map<IEnumerable<Order>>(orders));
        }
    }
}
