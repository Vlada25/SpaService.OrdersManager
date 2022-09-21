namespace OrdersManager.DTO.Schedule
{
    public class ScheduleForUpdateDto
    {
        public Guid MasterId { get; set; }
        public Guid ServiceId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MasterSurname { get; set; }
        public string MasterName { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        public string Address { get; set; }
    }
}
