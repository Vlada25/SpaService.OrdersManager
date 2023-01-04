using MassTransit;
using MediatR;
using OrdersManager.CQRS.Commands.Schedules;
using SpaService.Domain.Messages.Service;

namespace OrdersManager.Messaging.Consumers
{
    public class ServiceDeletedConsumer : IConsumer<ServiceDeleted>
    {
        private readonly IMediator _mediator;

        public ServiceDeletedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<ServiceDeleted> context)
        {
            var message = context.Message;

            await _mediator.Send(new UpdateSchedulesServiceDeletedCommand
            {
                ScheduleId = message.Id
            });
        }
    }
}
