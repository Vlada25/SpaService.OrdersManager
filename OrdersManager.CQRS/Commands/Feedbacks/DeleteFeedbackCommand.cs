using MediatR;

namespace OrdersManager.CQRS.Commands.Feedbacks
{
    public class DeleteFeedbackCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
