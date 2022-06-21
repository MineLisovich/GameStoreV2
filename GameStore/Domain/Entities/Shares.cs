using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameStore.Domain.Entities
{
    public class Shares
    {
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Введите новую цену")]
        public int discountPrice { get; set; }

        // связи с другими таблицами
        public AllGames AllGames { get; set; }
        public int AllGamesid { get; set; }
       

    }
}
