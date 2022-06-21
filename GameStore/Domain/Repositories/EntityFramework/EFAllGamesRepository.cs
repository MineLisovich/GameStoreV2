using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Repositories.Abstract;

namespace GameStore.Domain.Repositories.EntityFramework
{
    public class EFAllGamesRepository : IAllGamesRepository
    {
        private readonly AppDbContext context;
        public EFAllGamesRepository(AppDbContext context)
        { 
            this.context = context;
        }
        public IQueryable<AllGames> GetAllGames()
        {
            return context.AllGames;
        }

        public AllGames GetAllGamesByid(int id)
        {
            return context.AllGames.FirstOrDefault(x => x.id == id);
        }

        public AllGames GetAllGamesByCodeWord(string nameGame)
        {
            return context.AllGames.FirstOrDefault(x => x.nameGame == nameGame);
        }
        public void SaveAllGames(AllGames entity)
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
        public void DeleteAllGames(int id)
        {
            context.AllGames.Remove(new AllGames() { id = id });
            context.SaveChanges();
        }

      
    }
}
