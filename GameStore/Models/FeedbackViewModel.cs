using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Models
{
    public class FeedbackViewModel
    {
        [Required(ErrorMessage = "Введите ваш Email")]
        public string user_email { get; set; }
        [Required(ErrorMessage = "Введите ваше сообщение")]
        public string message { get; set; }
    }
}
