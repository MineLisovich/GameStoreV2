using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Domain.Entities;

namespace GameStore.Models
{
    public class LoginViewModel 
    {
        [Required(ErrorMessage = "Не указан Логин")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Не указан Пароль")]
        [UIHint("password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
