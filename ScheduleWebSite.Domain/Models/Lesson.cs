namespace ScheduleWebSite.Domain.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Schedule Schedule { get; set; }
        //public Comment Comment { get; set; }
    }
}
