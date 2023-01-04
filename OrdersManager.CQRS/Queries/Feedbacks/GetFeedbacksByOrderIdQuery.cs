using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Queries.Feedbacks
{
    public class GetFeedbacksByOrderIdQuery : IRequest<IEnumerable<Feedback>>
    {
        public Guid OrderId { get; set; }
    }
}
