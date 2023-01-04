using MassTransit;
using MediatR;
using OrdersManager.CQRS.Commands.Orders;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Messaging.Consumers
{
    public class ClientUpdatedConsumer : IConsumer<ClientUpdated>
    {
        private readonly IMediator _mediator;

        public ClientUpdatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ClientUpdated> context)
        {
            var message = context.Message;

            await _mediator.Send(new UpdateClientOrderCommand
            {
                ClientId = message.Id,
                ClientName = message.Name,
                ClientSurname = message.Surname
            });
        }
    }
}
