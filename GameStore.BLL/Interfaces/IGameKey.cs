using System;
using System.Collections.Generic;
using System.Text;
using GameStore.BLL.EntitiesDTO;

namespace GameStore.BLL.Interfaces
{
    public interface IGameKey
    {
        void Make(GameKeyDTO gameKeyDTO);
        GameKeyDTO GetById(int? id);
        GameKeyDTO GetByName(string name);
        IEnumerable<GameKeyDTO> GetAll();
        void Dispose();
    }
}
