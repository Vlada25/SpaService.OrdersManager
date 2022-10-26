using MediatR;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Feedbacks
{
    public class GetFeedbacksByOrderIdQuery : IRequest<IEnumerable<Feedback>>
    {
        public Guid OrderId { get; set; }
    }
}
