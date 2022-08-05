using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Models
{
    public class UserProfilViewModel
    {
        public IEnumerable<Basket> basket { get; set; }
        public IEnumerable<Cheque> cheque { get; set; }
        public  IdentityUser identityUser { get; set; }

        public int totalPrice { get; set; } 

    }
}
