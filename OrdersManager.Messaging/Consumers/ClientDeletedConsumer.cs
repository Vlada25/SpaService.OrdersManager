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

            _ordersService.DeleteByClientId(message.Id);
        }
    }
}
