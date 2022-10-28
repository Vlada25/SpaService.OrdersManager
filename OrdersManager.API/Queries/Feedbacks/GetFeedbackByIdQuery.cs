using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Feedbacks
{
    public class GetFeedbackByIdQuery : IRequest<Feedback>
    {
        public Guid Id { get; set; }
    }
}
