using MediatR;
using OrdersManager.Domain.Models;

namespace OrdersManager.API.Queries.Feedbacks
{
    public class GetAllFeedbacksQuery : IRequest<IEnumerable<Feedback>>
    {
    }
}
