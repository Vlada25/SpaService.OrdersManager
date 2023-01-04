using MassTransit;
using MediatR;
using OrdersManager.CQRS.Commands.Orders;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Messaging.Consumers
{
    public class ClientDeletedConsumer : IConsumer<ClientDeleted>
    {
        private readonly IMediator _mediator;

        public ClientDeletedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ClientDeleted> context)
        {
            var message = context.Message;

            await _mediator.Send(new UpdateOrderClientDeletedCommand
            {
                ClientId = message.Id
            });
        }
    }
}
