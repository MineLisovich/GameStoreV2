using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;

namespace GameStore.Domain.Repositories.Abstract
{
    public interface IGameKeyRepository
    {
        IQueryable<GameKey> GetGameKey();
        GameKey GetGameKeyByid(int id);
        GameKey GetGameKeyByCodeWord(string Key_game);
        void SaveGameKey(GameKey entity);
        void DeleteGameKey(int id);
    }
}
