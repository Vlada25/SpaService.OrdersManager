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
    public class ClientUpdatedConsumer : IConsumer<ClientUpdated>
    {
        private readonly IOrdersService _ordersService;

        public ClientUpdatedConsumer(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public async Task Consume(ConsumeContext<ClientUpdated> context)
        {
            var message = context.Message;

            _ordersService.UpdateClient(message);
        }
    }
}
