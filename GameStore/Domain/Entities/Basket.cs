using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Basket
    {

        [Required]
        public int id { get; set; }

        [Required]
        public int amount { get; set; }


        [Required]
        public int finalPrice { get; set; }


        // связи с другими таблицами



        public AllGames AllGames { get; set; }
        public int AllGamesid { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }



    }
}
