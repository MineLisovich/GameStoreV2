using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Models
{
    public class UserViewModel
    {
        public IEnumerable<IdentityUser> user { get; set; }
        public string Name { get; set; }
    }
}
