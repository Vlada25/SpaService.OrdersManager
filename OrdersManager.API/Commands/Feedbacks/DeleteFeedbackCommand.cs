using MediatR;

namespace OrdersManager.API.Commands.Feedbacks
{
    public class DeleteFeedbackCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
