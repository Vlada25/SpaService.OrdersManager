using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Feedbacks
{
    public class GetFeedbacksByOrderIdQuery : IRequest<IEnumerable<Feedback>>
    {
        public Guid OrderId { get; set; }
    }
}
