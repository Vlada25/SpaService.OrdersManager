using MediatR;

namespace OrdersManager.API.Commands.Feedbacks
{
    public class UpdateFeedbackCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Mark { get; set; }
    }
}
