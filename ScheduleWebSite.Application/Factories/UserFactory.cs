using ScheduleWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWebSite.Application.Factories
{
    public class UserFactory
    {
        public User Create(string login, string password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = "Новичок",
                Login = login,
                PasswordHash = password
            };
        }
    }
}
