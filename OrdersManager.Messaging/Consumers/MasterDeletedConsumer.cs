using MassTransit;
using MediatR;
using OrdersManager.CQRS.Commands.Schedules;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Messaging.Consumers
{
    public class MasterDeletedConsumer : IConsumer<MasterDeleted>
    {
        private readonly IMediator _mediator;

        public MasterDeletedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<MasterDeleted> context)
        {
            var message = context.Message;

            await _mediator.Send(new UpdateSchedulesMasterDeletedCommand
            {
                MasterId = message.Id
            });
        }
    }
}
