
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.EntitiesDTO
{
    public class BasketDTO
    {    
        public int id { get; set; }
        public int amount { get; set; }    
        public int finalPrice { get; set; }
        public int AllGamesid { get; set; }
        public string UserId { get; set; }
    }
}
