using MassTransit;
using MediatR;
using OrdersManager.CQRS.Commands.Schedules;
using SpaService.Domain.Messages.ServiceType;

namespace OrdersManager.Messaging.Consumers
{
    public class ServiceTypeUpdatedConsumer : IConsumer<ServiceTypeUpdated>
    {
        private readonly IMediator _mediator;

        public ServiceTypeUpdatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ServiceTypeUpdated> context)
        {
            var message = context.Message;

            await _mediator.Send(new UpdateServiceTypeScheduleCommand
            {
                ServiceTypeId = message.Id,
                ServiceTypeName = message.Name
            });
        }
    }
}
