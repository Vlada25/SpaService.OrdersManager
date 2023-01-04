using MassTransit;
using MediatR;
using OrdersManager.CQRS.Commands.Schedules;
using SpaService.Domain.Messages.Address;

namespace OrdersManager.Messaging.Consumers
{
    public class AddressUpdatedConsumer : IConsumer<AddressUpdated>
    {
        private readonly IMediator _mediator;

        public AddressUpdatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<AddressUpdated> context)
        {
            var message = context.Message;

            await _mediator.Send(new UpdateAddressScheduleCommand
            {
                AddressId = message.Id,
                Address = message.Address
            });
        }
    }
}
