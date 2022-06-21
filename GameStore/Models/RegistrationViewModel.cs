using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Не указан Логин")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Не указан Пароль")]
        [UIHint("passowrd")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }
    }
}
