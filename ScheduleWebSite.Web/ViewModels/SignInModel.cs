using System.ComponentModel.DataAnnotations;

namespace ScheduleWebSite.Web.ViewModels
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Логін не заповнений")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Пароль не заповнений")]
        public string Password { get; set; }
    }
}
