namespace OrdersManager.DTO.Feedback
{
    public class FeedbackDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Mark { get; set; }
        public Guid OrderId { get; set; }
    }
}
