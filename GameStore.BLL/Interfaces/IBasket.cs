using System;
using System.Collections.Generic;
using System.Text;
using GameStore.BLL.EntitiesDTO;

namespace GameStore.BLL.Interfaces
{
    public interface IBasket
    {
        void Make(BasketDTO basketDTO);
        BasketDTO GetById(int? id);
        BasketDTO GetByName(string name);
        IEnumerable<BasketDTO> GetAll();
        void Dispose();
    }
}
