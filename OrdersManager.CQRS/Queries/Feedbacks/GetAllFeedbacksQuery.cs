using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.CQRS.Queries.Feedbacks
{
    public class GetAllFeedbacksQuery : IRequest<IEnumerable<Feedback>>
    {
    }
}
