﻿namespace ScheduleWebSite.Models
{
    public class Lesson
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public Schedule Schedule { get; set; }
        //public Comment Comment { get; set; }
    }
}
