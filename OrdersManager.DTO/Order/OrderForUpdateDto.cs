namespace OrdersManager.DTO.Order
{
    public class OrderForUpdateDto
    {
        public Guid ClientId { get; set; }
        public Guid ScheduleId { get; set; }
        public string Status { get; set; }
        public string ClientSurmane { get; set; }
        public string ClientName { get; set; }
    }
}
