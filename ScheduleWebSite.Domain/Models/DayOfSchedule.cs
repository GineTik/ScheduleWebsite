namespace ScheduleWebSite.Domain.Models
{
    public class DayOfSchedule
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Lesson> Lessons { get; set; }

        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
