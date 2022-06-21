using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameStore.Domain.Entities
{
    public class Developers
    {    
        public int id { get; set; } 
        public string nameDeveloper { get; set; }

        public IList<AllGames> AllGames { get; set; }
    }
}
