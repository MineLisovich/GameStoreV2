using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameStore.Domain.Entities
{
    public class Developers
    {
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Введите Наименование разработчиков")]
        public string nameDeveloper { get; set; }

        public IList<AllGames> AllGames { get; set; }
    }
}
