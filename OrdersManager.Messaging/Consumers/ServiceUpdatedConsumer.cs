using MassTransit;
using MediatR;
using OrdersManager.CQRS.Commands.Schedules;
using SpaService.Domain.Messages.Service;

namespace OrdersManager.Messaging.Consumers
{
    public class ServiceUpdatedConsumer : IConsumer<ServiceUpdated>
    {
        private readonly IMediator _mediator;

        public ServiceUpdatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ServiceUpdated> context)
        {
            var message = context.Message;

            await _mediator.Send(new UpdateServiceScheduleCommand
            {
                ServiceId = message.Id,
                ServiceName = message.Name,
                ServiceAddress = message.Address,
                ServicePrice = message.Price
            });
        }
    }
}
