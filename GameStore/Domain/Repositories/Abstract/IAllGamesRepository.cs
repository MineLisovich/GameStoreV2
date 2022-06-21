using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Domain.Repositories.Abstract
{
    public interface IAllGamesRepository
    {
        IQueryable<AllGames> GetAllGames();
        AllGames GetAllGamesByid(int id);
        AllGames GetAllGamesByCodeWord(string nameGame);
        void SaveAllGames(AllGames entity);
        void DeleteAllGames(int id);
    }
}
