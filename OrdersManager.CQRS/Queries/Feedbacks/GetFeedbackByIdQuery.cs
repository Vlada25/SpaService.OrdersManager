using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Queries.Feedbacks
{
    public class GetFeedbackByIdQuery : IRequest<Feedback>
    {
        public Guid Id { get; set; }
    }
}
