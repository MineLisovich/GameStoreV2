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
    public class EFGanresRepository:IGanresRepository
    {
        private readonly AppDbContext context;
        public EFGanresRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Ganres> GetGanres()
        {
            return context.Ganres;
        }

        public Ganres GetGanresByid(int id)
        {
            return context.Ganres.FirstOrDefault(x => x.id == id);
        }

        public Ganres GetGanresByCodeWord(string nameGanres)
        {
            return context.Ganres.FirstOrDefault(x => x.nameGanres == nameGanres);
        }

        public void SaveGanres(Ganres entity)
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

        public void DeleteGanres(int id)
        {
            context.Ganres.Remove(new Ganres() { id = id });
            context.SaveChanges();
        }
    }
}
