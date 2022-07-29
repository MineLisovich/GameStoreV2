using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Cheque
    {
        [Required]
        public int id { get; set; }
        [Required]
        public DateTime dateAddedCheque { get; set; }

        public Basket Basket { get; set; }
        public int Basketid { get; set; }

       
    }
}
