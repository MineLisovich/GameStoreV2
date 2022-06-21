using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.EntitiesDTO
{
    public class RoleDTO : IdentityRole
    {  
        public new int Id { get; set; }
        public new string Name { get; set; }
    }
}
