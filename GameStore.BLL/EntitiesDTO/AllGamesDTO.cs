using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.EntitiesDTO
{
    public class AllGamesDTO
    {
        public int id { get; set; } 
        public string nameGame { get; set; }      
        public string descriptionG { get; set; }     
        public DateTime releaseDate { get; set; }      
        public int price { get; set; }      
        public int amount { get; set; }      
        public string Poster { get; set; }    
        public DateTime dateAddedSite { get; set; }
        public int Ganresid { get; set; }
        public int Developersid { get; set; }
        public int Platformsid { get; set; }
    }
}
