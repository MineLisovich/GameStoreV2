using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Shares> shares { get; set; }  
 
    }
}
