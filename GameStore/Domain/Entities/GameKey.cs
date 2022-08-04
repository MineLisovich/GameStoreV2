using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

namespace GameStore.Domain.Entities
{
    public class GameKey
    {
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Введите Ключ от игры")]
        public string Key_game { get; set; }

        public AllGames AllGames { get; set; }
        public int AllGamesid { get; set; }

        public IList<Cheque> Cheque { get; set; }

    }
}
