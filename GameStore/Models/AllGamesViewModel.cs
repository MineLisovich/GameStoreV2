
using System.Collections.Generic;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Models
{
    public class AllGamesViewModel
    {
        public IEnumerable<AllGames> allGames { get; set; }
        public SelectList GanresList { get; set; }
        public SelectList PlatfomsList { get; set; }
        public SelectList DevelopersList { get; set; }
        public string Name { get; set; }
        public int from { get; set; }
        public int before { get; set; }
        public IEnumerable<Shares> shares { get; set; }  
 
    }
}
