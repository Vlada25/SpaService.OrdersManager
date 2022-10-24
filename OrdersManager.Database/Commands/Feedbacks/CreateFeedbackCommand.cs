using MediatR;
using OrdersManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Commands.Feedbacks
{
    public class CreateFeedbackCommand : IRequest<Feedback>
    {
        public string Comment { get; set; }
        public int Mark { get; set; }
        public Guid OrderId { get; set; }
    }
}
