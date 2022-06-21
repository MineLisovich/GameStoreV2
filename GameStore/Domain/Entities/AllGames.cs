using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class AllGames
    {
       
        

        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "Введите Наименование игры")]
        public string nameGame { get; set; }

        [Required(ErrorMessage = "Введите Описаниае игры")]
        public string descriptionG { get; set; }

        [Required(ErrorMessage = "Введите Дату выхода игры")]
        public DateTime releaseDate { get; set; }

        [Required(ErrorMessage = "Введите Стоимость игры")]
        public int price { get; set; }

        [Required(ErrorMessage = "Введите Количество копий игры")]
        public int amount { get; set; }

        [Required(ErrorMessage = "Введите Имя картинки")]
        public string Poster { get; set; }

        [Required]
        public DateTime dateAddedSite { get; set; }

        // связи с другими таблицами
        public Ganres Ganres { get; set; }
        public int Ganresid { get; set; }
        public Developers Developers { get; set; }
        public int Developersid { get; set; }

        public Platforms Platforms { get; set; }
        public int Platformsid { get; set; }
       
        public IList<Shares> Shares { get; set; }

        public IList<Basket> Basket { get; set; }

        public IList<GameKey> GameKeys { get; set; }

        

      

    }
}
