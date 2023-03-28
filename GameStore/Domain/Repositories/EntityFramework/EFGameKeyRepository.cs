using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Domain.Repositories.EntityFramework
{
    public class EFGameKeyRepository : IGameKeyRepository
    {
        private readonly AppDbContext context;
        public EFGameKeyRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<GameKey> GetGameKey()
        {
            return context.GameKey.Include(a => a.AllGames);
        }

        public GameKey GetGameKeyByid(int id)
        {
            return context.GameKey.FirstOrDefault(x => x.id == id);
        }

        public GameKey GetGameKeyByCodeWord(string Key_game)
        {
            return context.GameKey.FirstOrDefault(x => x.Key_game == Key_game);
        }
        public void SaveGameKey(GameKey entity)
        {
            if (entity.id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public void DeleteGameKey(int id)
        {
            context.GameKey.Remove(new GameKey() { id = id });
            context.SaveChanges();
        }


    }
}
