using ScheduleWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWebSite.Application.Factories
{
    public class DayOfScheduleFactory
    {
        public DayOfSchedule Create(Guid scheduleId)
        {
            return new DayOfSchedule()
            {
                Id = Guid.NewGuid(),
                Name = "Новий день",
                ScheduleId = scheduleId
            };
        }
    } 
}
