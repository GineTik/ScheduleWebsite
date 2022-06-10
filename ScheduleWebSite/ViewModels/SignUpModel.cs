using System.ComponentModel.DataAnnotations;

namespace ScheduleWebSite.ViewModels
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Логін не заповнений")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пароль не заповнений")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль не співпадає")]
        public string ConfirmPassword { get; set; }
    }
}
