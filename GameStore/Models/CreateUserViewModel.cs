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
    public class CreateUserViewModel
    {
        [Required (ErrorMessage = "Не указано ") ]
        public string Name { get; set; }

        [Required (ErrorMessage =("Не указана "))]
        public string Email { get; set; }

        [Required (ErrorMessage =("Не был введён "))]
        public string Password { get; set; }

        [Required(ErrorMessage = ("Не был введён "))]
        public string RoleID { get; set; }

        [Required(ErrorMessage = ("Не был введён "))]
        public string Role { get; set; }
    }
}
