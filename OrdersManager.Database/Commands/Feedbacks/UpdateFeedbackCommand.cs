using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Database.Commands.Feedbacks
{
    public class UpdateFeedbackCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Mark { get; set; }
    }
}
