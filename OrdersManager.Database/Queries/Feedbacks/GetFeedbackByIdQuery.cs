using MediatR;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Queries.Feedbacks
{
    public class GetFeedbackByIdQuery : IRequest<Feedback>
    {
        public Guid Id { get; set; }
    }
}
