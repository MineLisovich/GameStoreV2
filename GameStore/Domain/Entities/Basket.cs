﻿using Microsoft.AspNetCore.Identity;
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



        public GameKey GameKey { get; set; }
        public int GameKeyid { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public IList<Cheque> Cheque { get; set; }


    }
}
