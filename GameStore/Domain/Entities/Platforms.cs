using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameStore.Domain.Entities
{
    public class Platforms
    {

        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Введите Наименование платформы")]
        public string namePlatform { get; set; }

        public List<AllGames> AllGames { get; set; }
      
    }
}
