using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace GameStore.Domain.Entities
{
    public class Ganres
    {
       

        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Введите Наименование жанра")]
        public string nameGanres { get; set; }

        

       public ICollection<AllGames> GanresAllGames { get; set; }
      

        public Ganres()
        { 
            
            GanresAllGames = new List<AllGames>();
        }
      

    }
}
