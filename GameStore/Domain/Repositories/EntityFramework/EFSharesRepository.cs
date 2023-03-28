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
    public class EFSharesRepository:ISharesRepository
    {
        private readonly AppDbContext context;
        public EFSharesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Shares> GetShares()
        {
            return context.Shares.Include(a => a.AllGames);
        }
        public Shares GetSharesByid(int id)
        {
            return context.Shares.FirstOrDefault(x => x.id == id);
        }

        public void SaveShares(Shares entity)
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

        public void DeleteShares(int id)
        {
            context.Shares.Remove(new Shares() { id = id });
            context.SaveChanges();
        }
    }
}
