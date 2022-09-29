namespace OrdersManager.DTO.Feedback
{
    public class FeedbackForCreationDto
    {
        public string Comment { get; set; }
        public int Mark { get; set; }
        public Guid OrderId { get; set; }
    }
}
