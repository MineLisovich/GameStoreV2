using System;
using System.Collections.Generic;
using System.Text;
using GameStore.BLL.EntitiesDTO;

namespace GameStore.BLL.Interfaces
{
    public interface IAllGames
    {
        void Make(AllGamesDTO allGamesDTO);
        AllGamesDTO GetById(int? id);
        AllGamesDTO GetByName (string name);
        IEnumerable<AllGamesDTO> GetAll();
        void Dispose();
    }
}
