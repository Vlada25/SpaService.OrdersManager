using MassTransit;
using MediatR;
using OrdersManager.CQRS.Commands.Schedules;
using SpaService.Domain.Messages.Person;

namespace OrdersManager.Messaging.Consumers
{
    public class MasterUpdatedConsumer : IConsumer<MasterUpdated>
    {
        private readonly IMediator _mediator;

        public MasterUpdatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<MasterUpdated> context)
        {
            var message = context.Message;

            await _mediator.Send(new UpdateMasterScheduleCommand
            {
                MasterId = message.Id,
                MasterName = message.Name,
                MasterSurname = message.Surname
            });
        }
    }
}
