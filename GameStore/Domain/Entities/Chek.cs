using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Chek
    {
        [Required]
        public int id { get; set; }
        [Required]
        public DateTime dateAddedCheque { get; set; }

        public IdentityUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string nameGame { get; set; }
        [Required]
        public int priceGame { get; set; }
        [Required]
        public GameKey GameKey { get; set; }
        public int GameKeyid { get; set; }
    }
}
