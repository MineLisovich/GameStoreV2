﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Domain.Entities;

namespace GameStore.Models
{
    public class GameKeyViewModel
    {
       
        public IEnumerable<GameKey> gameKey { get; set; }
        public string Name { get; set; }
    }
}
