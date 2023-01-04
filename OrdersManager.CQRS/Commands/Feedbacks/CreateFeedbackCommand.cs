using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Commands.Feedbacks
{
    public class CreateFeedbackCommand : IRequest<Feedback>
    {
        public string Comment { get; set; }
        public int Mark { get; set; }
        public Guid OrderId { get; set; }
    }
}
